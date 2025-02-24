using UnityEngine;

namespace CameraFollow
{
    public class CameraFollow : MonoBehaviour
    {
        // Reference to the player's transform.
        public Transform player;

        // Optional offset from the player's position. Adjust in Inspector.
        public Vector3 offset;

        // Smooth factor for camera movement. Higher values mean faster following.
        public float smoothSpeed = 0.125f;

        // Update is called once per frame.
        void LateUpdate()
        {
            // Desired camera position based on player's position plus the offset.
            Vector3 desiredPosition = player.position + offset;
            // Smoothly interpolate from current position to desired position.
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            // Update the camera's position.
            transform.position = smoothedPosition;
        }
    }
}
