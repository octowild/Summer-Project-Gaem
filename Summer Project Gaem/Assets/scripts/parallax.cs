using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour
{
    private Vector2 length, startpos;
    public GameObject cam;
    public float paraeff;
    void Start()
    {
        startpos.x = transform.position.x;
        length.x = GetComponent<SpriteRenderer>().bounds.size.x;
    }


    void Update()
    {
        
    }
}
