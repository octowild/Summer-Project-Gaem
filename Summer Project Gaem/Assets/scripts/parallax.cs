using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour
{
    private Vector2 length, startpos;
    public GameObject cam;
    public float paraeff;
    public float paraeffy;
    void Start()
    {
        startpos = transform.position;
        length.x = GetComponent<SpriteRenderer>().bounds.size.x;
        length.y = GetComponent<SpriteRenderer>().bounds.size.y;
    }


    void Update()
    {
        float temp = (cam.transform.position.x * (1 - paraeff));
        float dist = (cam.transform.position.x * paraeff);
        transform.position = new Vector3(startpos.x + dist, transform.position.y, transform.position.z);
        if (temp > startpos.x + length.x) startpos.x += length.x;
        else if (temp < startpos.x - length.x) startpos.x -= length.x;
    }
}
