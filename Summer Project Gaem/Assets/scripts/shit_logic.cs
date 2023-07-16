using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shitlogic : MonoBehaviour
{
    public float fallspeed;
    public CapsuleCollider2D capcol;
    public CircleCollider2D circol;
    public Animator anim;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;


    void Start()
    {
        
    }


    void Update()
    {
        float speed = fallspeed;
        if (IsGrounded())
        {
            speed = 0;
            anim.SetBool.splash = true;
        }
        transform.position += Vector3.down * speed * Time.deltaTime;
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}
