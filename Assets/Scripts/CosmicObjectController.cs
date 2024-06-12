using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CosmicObjectController : MonoBehaviour
{
    public Color objectColor; // Color of the cosmic object
    private Rigidbody2D rb; // Rigidbody component
    public float mergeScaleMultiplier = 1.5f;
    private bool isMerged = false;
    public GameObject MergeEffect;
    public GameObject DestoryEffect;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Method to activate the gravitational field of the object
    public void ActivateGravity(Vector2 targetPosition)
    {
        Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;
        rb.AddForce(direction * 1000f); // Adjust force as needed
    }

    // Method to handle collision with another cosmic object
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (!isMerged && collision.gameObject.CompareTag("CosmicObject"))
        {
            CosmicObjectController collidedObject = collision.gameObject.GetComponent<CosmicObjectController>();
            if (collidedObject != null && collidedObject.objectColor == objectColor)
            {
                
                // Merge the two objects
                MergeWith(collidedObject);
                
            }
        }
       

    }
    private void MergeWith(CosmicObjectController other)
    {
        Instantiate(MergeEffect, transform.position, Quaternion.identity);
        // Increase size upon merging
        transform.localScale *= mergeScaleMultiplier;
        isMerged = true;
        other.isMerged = true;

        // Destroy the other cosmic object
        Destroy(other.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isMerged && other.CompareTag("CosmicObject"))
        {
            CosmicObjectController collidedObject = other.GetComponent<CosmicObjectController>();
            if (collidedObject != null && collidedObject.objectColor == objectColor && !collidedObject.isMerged)
            {
                Instantiate(DestoryEffect, transform.position, Quaternion.identity);
                // Increase score and destroy both objects
                GameManager.Instance.TriggerChainReaction(objectColor);
                Destroy(gameObject);
                Destroy(other.gameObject);
            }
        }
    }
        private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, 1f);
    }
   

   
}
