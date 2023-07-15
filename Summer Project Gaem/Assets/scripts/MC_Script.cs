using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MC_Script : MonoBehaviour
{
    public float movespeed;
    public float jumpstr;
    public float jumptime;
    public Rigidbody2D mcrb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    private float sideinput;
    private bool isjumping;
    private float jumptimer;




    void Start()
    {

    }


    void Update()
    {
        sideinput = Input.GetAxisRaw("Horizontal");




        mcrb.velocity = new Vector2(sideinput * movespeed * Time.deltaTime, mcrb.velocity.y);



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
    }
            
        
    private void FixedUpdate()
    {

    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}