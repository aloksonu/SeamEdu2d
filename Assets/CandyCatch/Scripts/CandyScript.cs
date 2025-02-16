using UnityEngine;

namespace CandyCatch
{
    public class CandyScript : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.tag == "Player")
            {
                GameManager.instance.IncrementScore();
                Destroy(gameObject);
            }

            else if (collider.gameObject.tag == "Boundary")
            {
                GameManager.instance.DecreaseLife();
                Destroy(gameObject);
            }
        }

    }
}
