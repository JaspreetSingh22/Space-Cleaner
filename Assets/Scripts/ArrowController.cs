using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    SpriteRenderer crossSpiteRendere;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        crossSpiteRendere = GameObject.Find("Crossair").GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        // Rotate the arrow towards the mouse cursor position when hovering over a cosmic body
        RotateArrowTowardsMouse();
    }

   


    void RotateArrowTowardsMouse()
     {
            // Cast a ray from the mouse cursor position
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
        transform.position = mousePosition;
            // Check if the ray hits a cosmic body
            if (hit.collider != null && hit.collider.CompareTag("CosmicObject"))
        {
            spriteRenderer.enabled = true;
            crossSpiteRendere.enabled = false;
            // Calculate direction towards the cosmic body
            Vector2 direction = hit.collider.transform.position - transform.position;

                // Rotate the arrow towards the cosmic body
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
        else
        {
            spriteRenderer.enabled = false;
            crossSpiteRendere.enabled = true;
        }
        
    }
}

   

