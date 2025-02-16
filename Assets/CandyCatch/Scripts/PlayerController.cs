using UnityEngine;

namespace CandyCatch
{
    public class PlayerController : MonoBehaviour
    {
        public static PlayerController instance;    
        internal bool canMove;
        [SerializeField] float moveSpeed; //15
        [SerializeField] float maxPos;  //6.7

        private void Awake()
        {
            if (instance == null) {
                instance = this;
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            canMove = true;
        }

        // Update is called once per frame
        void Update()
        {
            if (canMove)
            {
                move();
            }
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
