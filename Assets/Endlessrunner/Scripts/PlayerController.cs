using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



namespace Endlessrunner.Scripts
{ 
public class PlayerController : MonoBehaviour
{

    Rigidbody2D rb2d;
    [SerializeField]
    float jumpForce;
    Animator animator;
    bool grounded;

    private AudioManager audioManager;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        audioManager = AudioManager.instance;
    }

    // Update is called once per frame
    void Update()
    {

        if ((Input.GetMouseButtonDown(0)))
        {
            if (grounded && ObstacleSpawner.instance.gameOver == false)
            {
                jump();

            }
         }
       }

    void jump()
    {
        audioManager.PlaySFX(audioManager.jumpClip);
        rb2d.velocity = Vector2.up * jumpForce;
        grounded = false;
        animator.SetTrigger("Jump");

        if(ObstacleSpawner.instance.gameOver==false)
        ScorePanel.instance.UpdateScore(1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") {

            grounded = true;
            animator.SetTrigger("Run");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacles")
        {

            Destroy(collision.gameObject);
            animator.Play("Dead");
            GameManager.instance.GameOver();
            audioManager.PlaySFX(audioManager.deadClip);
            //ScorePanel.instance.UpdateScore(-1);
        }
    }
 }
}
