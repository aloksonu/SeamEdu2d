using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureScroll : MonoBehaviour
{
    public float speed;
    public Material scrollMaterial;
    public bool scroll = true;
    void Start()
    {
       // scrollMaterial = GetComponent<Material>();

    }

    private void FixedUpdate()
    {
        if (scroll) { 
        Vector2 offSet = new Vector2(speed * Time.time, 0);
        scrollMaterial.mainTextureOffset = offSet;
        }
    }

}
