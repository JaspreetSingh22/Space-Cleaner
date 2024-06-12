using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f; // Adjust this to control player speed
    [SerializeField] float maxX = 40f; // Maximum X position
    [SerializeField] float minX = -40f; // Minimum X position
    [SerializeField] float maxY = 20f; // Maximum Y position
    [SerializeField] float minY = -20f; // Minimum Y position

    // Update is called once per frame
    void Update()
    {
        // Get input from player
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate new position
        float newX = transform.position.x + horizontalInput * moveSpeed * Time.deltaTime;
        float newY = transform.position.y + verticalInput * moveSpeed * Time.deltaTime;

        // Clamp position within boundaries
        newX = Mathf.Clamp(newX, minX, maxX);
        newY = Mathf.Clamp(newY, minY, maxY);

        // Update player position
        transform.position = new Vector2(newX, newY);
    }
}
