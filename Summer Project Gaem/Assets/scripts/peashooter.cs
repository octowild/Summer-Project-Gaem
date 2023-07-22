using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class peashooter : MonoBehaviour
{
    public GameObject mc;
    public GameObject bullet;
    public float shootspeed;
    private float timer;

    void Start()
    {
        mc = GameObject.FindGameObjectWithTag("Player");
    }


    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer >= shootspeed)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            timer = 0;
        }
    }
}
