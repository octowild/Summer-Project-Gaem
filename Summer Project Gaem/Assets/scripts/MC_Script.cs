using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MC_Script : MonoBehaviour
{
    public int hp;
    public float movespeed;
    public float jumpstr;
    public float jumptime;
    public Rigidbody2D mcrb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    public keyleaflogic key;
    public Logicmain logic;
    private float sideinput;
    private bool isjumping;
    private float jumptimer;
    public int haskey;
    public bool mcinteract;
    public bool doorinteract;




    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<Logicmain>();
    }

    private void FixedUpdate()
    {
       
       

    }
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            isjumping = true;
            jumptimer = jumptime;
            mcrb.velocity = Vector2.up * jumpstr;
        }
        if (Input.GetKey(KeyCode.Space) && isjumping)
        {
            if (jumptimer > 0)
            {
                mcrb.velocity = Vector2.up * jumpstr;
                jumptimer -= Time.deltaTime;
            }
            else
            {
                isjumping = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isjumping = false;
        }
        sideinput = Input.GetAxisRaw("Horizontal");
        mcrb.velocity = new Vector2(sideinput * movespeed, mcrb.velocity.y);

        if (Input.GetKeyDown(KeyCode.E)&&key.ininteractzone)
        {
            haskey += 1;
            mcinteract = true;
            
        }
        if (Input.GetKeyDown(KeyCode.E) && logic.vdoorinteract)
        {
            doorinteract = true;
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            doorinteract = false;
        }
    }



    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}