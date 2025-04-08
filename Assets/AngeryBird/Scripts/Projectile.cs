using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpringJoint2D springJoint;
    private bool isPressed;

    public Animator[] cageAnimator;
    public Animator[] birdAnimator;
    public GameObject[] bird;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        springJoint = GetComponent<SpringJoint2D>();
    }

    void Update()
    {
        if (isPressed)
        {
            rb.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    private void OnMouseDown()
    {
        isPressed = true;
        rb.isKinematic = true;
    }
    private void OnMouseUp()
    {
        isPressed = false;
        rb.isKinematic = false;
        StartCoroutine(Release());
    }

    IEnumerator Release()
    {
        yield return new WaitForSeconds(0.15f);
        GetComponent<SpringJoint2D>().enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Boundary")
        {
            Debug.Log("Hit Boundary");
            foreach (var cage in cageAnimator)
            {
                cage.Play("ACageBreak");
                Destroy(cage.gameObject, 3f);
            }
            foreach (var bird in birdAnimator)
            {
                bird.Play("Fly");
                Destroy(bird.gameObject, 3f);
            }
            foreach (var item in bird)
            {
                item.GetComponent<BirdFly>().enabled = true;
            }
        }
    }

}
