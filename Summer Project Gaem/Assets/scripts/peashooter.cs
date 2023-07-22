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
    private bool faceleft;

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

        if (xdiff > 0 && !faceleft)
        {
            flip();
        }
        else if (xdiff < 0 && faceleft)
        {
            flip();
        }
    }
    void flip()
    {
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
        faceleft = !faceleft;
    }
}
