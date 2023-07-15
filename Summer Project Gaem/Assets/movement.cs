using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private float horizontal;
    public float speed = 8f;
    [SerializeField] private float jumpHeight = 5f;
    private bool isFacingRight = true;
    private bool jump = false;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] float gravityScale = 5f;
    [SerializeField] float fallGravityScale = 15f;
    //[SerializeField] float buttonpressWindow;

    private void Awake()
    {
    
    }
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            jump = true;
        }
        
        if (Input.GetButtonUp("Jump"))
        {
            jump = false;
        }

        Flip();

    }
    private void FixedUpdate()
    {
        if (IsGrounded())
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
            if (jump)
            {
                rb.gravityScale = gravityScale;
                float jumpforce = Mathf.Sqrt(jumpHeight * (Physics2D.gravity.y * rb.gravityScale) * -2) * rb.mass;
                rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
            }
        }

        else  if (!IsGrounded())
        {
            if (rb.velocity.x * horizontal < speed * horizontal)
            {
                rb.velocity += Vector2.right * speed * 1/3;
            }
            if (!jump)
            {
                rb.gravityScale = fallGravityScale;
            }
            
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal <0f || !isFacingRight && horizontal >0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale; 
        }
    }
}
