using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brib : MonoBehaviour
{
    public Animator anim;
    public GameObject shit;
    public GameObject mc;

    void Start()
    {
        mc = GameObject.FindGameObjectWithTag("Player");
    }


    void Update()
    {
        if (transform.position.x == mc.transform.position.x)
        {
            Instantiate(shit, transform.position, transform.rotation);
        }
        
    }
}
