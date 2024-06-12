using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
   

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPosition, Vector2.zero);

            if (hit.collider != null)
            {
                CosmicObjectController cosmicObject = hit.collider.GetComponent<CosmicObjectController>();
                if (cosmicObject != null)
                {
                    cosmicObject.ActivateGravity(worldPosition);    
                }
            }
        }
    }
   
}
