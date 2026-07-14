using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private float speed = 5f; // Speed of the player movement
    [SerializeField] private float jumpForce = 5f; // Force applied when jumping
    [SerializeField] private LayerMask groundLayer; // Layer mask to identify ground objects

    private Rigidbody rb; // Reference to the Rigidbody component
    private bool isGrounded; // Flag to check if the player is on the ground

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component attached to the player
    }

    private void Update()
    {
        Move(); // Handle player movement
        Jump(); // Handle player jumping
    }

    private void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // Get horizontal input (A/D or Left/Right arrow keys)
        float moveVertical = Input.GetAxis("Vertical"); // Get vertical input (W/S or Up/Down arrow keys)

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical); // Create a movement vector based on input
        rb.AddForce(movement * speed); // Apply force to the Rigidbody for movement
    }

    private void Jump()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f, groundLayer); // Check if the player is grounded using a raycast

        if (isGrounded && Input.GetButtonDown("Jump")) // If grounded and jump button is pressed
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // Apply an upward force for jumping
        }
    }
}
