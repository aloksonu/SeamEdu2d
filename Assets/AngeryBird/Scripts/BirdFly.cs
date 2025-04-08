using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BirdFly : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.transform.DOMove(new Vector3(-3.06f, 5.88f, 0), 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
