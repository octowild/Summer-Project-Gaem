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
    public Logicmain logic;
    private float sideinput;
    private bool isjumping;
    private float jumptimer;
    public bool mcinteracts;




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

        if (Input.GetKeyDown(KeyCode.E)&&logic.caninteract)
        {
            mcinteracts = true;
        }
    }



    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}