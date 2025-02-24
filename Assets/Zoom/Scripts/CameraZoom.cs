using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zoom
{
    public class CameraZoom : MonoBehaviour
    {
        // Reference to the Camera that will be zoomed. Set this in the Inspector.
        public Camera cam;
        // Speed multiplier for how fast the zoom occurs.
        public float zoomSpeed = 5f;
        // Minimum allowed orthographic size (limits zooming in too much).
        public float minZoom = 2f;
        // Maximum allowed orthographic size (limits zooming out too far).
        public float maxZoom = 10f;

        private float targetZoom;
        // Start is called before the first frame update
        void Start()
        {
            targetZoom = cam.orthographicSize;
        }

        // Update is called once per frame
        void Update()
        {
            // ZoomByMouse();

            SmoothZoom();
        }

        private void ZoomByMouse()
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            cam.orthographicSize -= scroll * zoomSpeed;
            cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, minZoom, maxZoom);
        }

        private void SmoothZoom()
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            targetZoom -= scroll * zoomSpeed;
            targetZoom = Mathf.Clamp(targetZoom, minZoom, maxZoom);
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetZoom, Time.deltaTime * 5f);
        }

        private void PinchZoom()
        {
            // Check if two touches are on the screen (i.e., a pinch gesture).
            if (Input.touchCount == 2)
            {
                // Get data for the first touch.
                Touch touch0 = Input.GetTouch(0);
                // Get data for the second touch.
                Touch touch1 = Input.GetTouch(1);

                // Calculate the position of the first touch in the previous frame.
                Vector2 touch0Prev = touch0.position - touch0.deltaPosition;
                // Calculate the position of the second touch in the previous frame.
                Vector2 touch1Prev = touch1.position - touch1.deltaPosition;

                // Calculate the distance between the two touches in the previous frame.
                float prevMagnitude = (touch0Prev - touch1Prev).magnitude;
                // Calculate the distance between the two touches in the current frame.
                float currentMagnitude = (touch0.position - touch1.position).magnitude;
                // Determine the change in distance between frames.
                float difference = currentMagnitude - prevMagnitude;

                // Adjust the camera's orthographic size based on the change in distance,
                // multiplied by the zoom speed factor.
                cam.orthographicSize -= difference * zoomSpeed;
                // Ensure the new orthographic size is within the defined min and max zoom limits.
                cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, minZoom, maxZoom);
            }
        }
    }
}
