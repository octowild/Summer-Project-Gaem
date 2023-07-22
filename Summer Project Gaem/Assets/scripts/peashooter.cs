using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class peashooter : MonoBehaviour
{
    public GameObject mc;
    public GameObject bullet;
    public float shootspeed;
    private float timer;
    public Vector2 trigrange;
    private float xdiff;
    private float ydiff;

    void Start()
    {
        mc = GameObject.FindGameObjectWithTag("Player");
    }


    void FixedUpdate()
    {
        xdiff = mc.transform.position.x - transform.position.x;
        ydiff = mc.transform.position.y - transform.position.y;
        
        timer += Time.deltaTime;
        if (trigrange.x>=Mathf.Abs(xdiff)&& trigrange.y >= Mathf.Abs(ydiff) && timer >= shootspeed)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            timer = 0;
        }
    }
}
