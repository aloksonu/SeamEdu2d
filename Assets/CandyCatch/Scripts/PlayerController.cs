using UnityEngine;

namespace CandyCatch
{
    public class PlayerController : MonoBehaviour
    {
        bool canMove = true;
        [SerializeField] float moveSpeed; //15
        [SerializeField] float maxPos;  //6.7

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            move();
        }
        private void move()
        {
            float inputX = Input.GetAxis("Horizontal");
            transform.position += Vector3.right * inputX * moveSpeed * Time.deltaTime;
            float xPos = Mathf.Clamp(transform.position.x, -maxPos, maxPos);
            transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
        }

    }
}
