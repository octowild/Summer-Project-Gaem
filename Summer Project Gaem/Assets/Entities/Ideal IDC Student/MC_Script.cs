using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MC_Script : MonoBehaviour
{
    public Rigidbody2D mcrigidbody;
    public float movespeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal"))
        {
            transform.position += Input.GetAxisRaw("Horizontal") * Vector3.right * movespeed * Time.deltaTime;
        }
 
       
    }
}