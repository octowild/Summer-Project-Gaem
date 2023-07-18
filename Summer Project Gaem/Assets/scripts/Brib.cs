using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brib : MonoBehaviour
{
    public Animator anim;
    public GameObject shit;
    public GameObject mc;
    public float offset;
    public float timebwshits;
    private float timer;

    void Start()
    {
        mc = GameObject.FindGameObjectWithTag("Player");
    }


    void Update()
    {
        timer += Time.deltaTime;
        if (offset >= Mathf.Abs(transform.position.x - mc.transform.position.x)&&timer>=timebwshits)
        {
            Instantiate(shit, transform.position, transform.rotation);
            timer = 0;

        }
        
        
            
        
        
        
        
    }
}
