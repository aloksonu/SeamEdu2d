using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace LeftRight
{
    public class PlayerController : MonoBehaviour
    {

        // Speed at which the player moves
        public float moveSpeed = 5f;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            MovePlayerByArrow();
        }


        private void MovePlayerByArrow()
        {
            // Get horizontal input from left/right arrow keys or A/D keys.
            // Returns a value between -1 and 1 (-1 for left, 1 for right, 0 if no input)
            float horizontalInput = Input.GetAxis("Horizontal");

            // Calculate movement vector in the x direction
            Vector3 movement = new Vector3(horizontalInput * moveSpeed * Time.deltaTime, 0f, 0f);

            // Apply movement to the player's transform position
            transform.Translate(movement);
        }
    }
}
