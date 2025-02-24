using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LeftRightUP
{
    public class PlayerController1 : MonoBehaviour
    {
        public float moveSpeed = 5f; // Speed of left/right movement
        public float jumpForce = 7f; // Jump strength
        private bool isGrounded; // Checks if the player is on the ground

        private Rigidbody2D rb; // Reference to Rigidbody2D component
        void Start()
        {
            // Get the Rigidbody2D component attached to the player
            rb = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            // Get horizontal movement input (-1 for left, 1 for right, 0 if no input)
            float horizontalInput = Input.GetAxis("Horizontal");

            // Move the player left/right
            rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

            // Check if the player presses the Space key and is grounded
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                // Apply upward force for jumping
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }

        // Detects when the player touches the ground (to allow jumping)
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                isGrounded = true; // Player is on the ground
            }
        }

        // Detects when the player leaves the ground (to prevent double jumping)
        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                isGrounded = false; // Player is in the air
            }
        }
    }
}
