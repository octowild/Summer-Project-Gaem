using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brib : MonoBehaviour
{
    public Animator anim;
    public GameObject shit;
    public GameObject mc;
    public float offset;
    private bool overlap;

    void Start()
    {
        mc = GameObject.FindGameObjectWithTag("Player");
    }


    void Update()
    {
        float birbpos = transform.position.x;
        float mcpos = mc.transform.position.x;
        if (offset == Mathf.Abs(birbpos - mcpos))
        {
            overlap = true;
        }
        else
        {
            overlap = false;
        }
        if (overlap)
        {
            Debug.Log("overlap");
            Instantiate(shit, transform.position, transform.rotation);
        }
        
    }
}
