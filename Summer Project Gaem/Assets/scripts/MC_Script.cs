using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MC_Script : MonoBehaviour
{
    public int maxhp;
    public float movespeed;
    public float jumpstr;
    public float jumptime;
    public Rigidbody2D mcrb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    public keyleaflogic key;
    public Logicmain logic;
    public GameObject spawn;
    private float sideinput;
    private bool isjumping;
    private float jumptimer;
    public int haskey;
    public bool mcinteract;
    public bool doorinteract;
    public bool hit;
    public int dmgtaken;
    public bool isded;
    public int c_hp;
    




    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<Logicmain>();
        spawn = GameObject.FindGameObjectWithTag("playerspawn");
        c_hp = maxhp;
    }

    private void FixedUpdate()
    {

        c_hp -= dmgtaken;
        dmgtaken = 0;
        if (c_hp <= 0)
        {
            isded = true;
        }
        //if(respawn)
        //{ 
        //    c_hp = maxhp;
        //    isded = false;
        //    transform.position = spawn.transform.position;
        //}
    }
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded()&&!isded)
        {
            isjumping = true;
            jumptimer = jumptime;
            mcrb.velocity = Vector2.up * jumpstr;
        }
        if (Input.GetKey(KeyCode.Space) && isjumping&&!isded)
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
        if (!isded)
        {
            sideinput = Input.GetAxisRaw("Horizontal");
        } else { sideinput = 0; }
        
        mcrb.velocity = new Vector2(sideinput * movespeed, mcrb.velocity.y);

        if (Input.GetKeyDown(KeyCode.E)&&key.ininteractzone&&!isded)
        {
            haskey += 1;
            mcinteract = true;
            
        }
        if (Input.GetKeyDown(KeyCode.E) && logic.vdoorinteract&&!isded)
        {
            doorinteract = true;
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            doorinteract = false;
            mcinteract = false;
        }
    }



    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}