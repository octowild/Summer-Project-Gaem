using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shitlogic : MonoBehaviour
{
    public float fallspeed;
    public Animator anim;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    public Logicmain logic;
    private float speed;
    public bool s_hit;


    void Start()
    {
        speed = fallspeed;
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<Logicmain>();
    }


    void Update()
    {
        
        if (IsGrounded())
        {
            speed = 0;
            anim.SetBool("splash",true);
            

        }
        transform.position += Vector3.down * speed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        s_hit = true;
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
    }
}
