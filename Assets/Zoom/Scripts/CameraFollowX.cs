using UnityEngine;

public class CameraFollowX : MonoBehaviour
{
    // Reference to the player's transform (drag your player GameObject here in the Inspector)
    public Transform player;

    // Optional offset in the x-direction (you can adjust this in the Inspector)
    public float offsetX = 0f;

    // Smooth factor for camera movement on the x-axis
    public float smoothSpeed = 0.125f;

    // LateUpdate ensures the camera moves after the player has moved for the frame
    void LateUpdate()
    {
        // Get the current camera position
        Vector3 currentPosition = transform.position;

        // Calculate the target x position based on the player's x position plus an offset
        float targetX = player.position.x + offsetX;

        // Smoothly interpolate the camera's x position toward the target x position
        currentPosition.x = Mathf.Lerp(currentPosition.x, targetX, smoothSpeed);

        // Update the camera position while keeping the original y and z values
        transform.position = currentPosition;
    }
}
