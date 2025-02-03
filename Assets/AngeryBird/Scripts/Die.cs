using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    public GameObject Bird;
    public GameObject Pattern;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            //Instantiate(Pattern, transform.position, Quaternion.identity);
            Destroy(Bird);
        }
    }

    private void Destroy()
    {
        Destroy(Bird);
        Instantiate(Pattern, transform.position, Quaternion.identity);
    }

}
