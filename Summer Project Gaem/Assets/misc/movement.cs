using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private float horizontal;
    public float speed = 8f;
    [SerializeField] private float jumpHeight = 5f;
    private bool isFacingRight = true;

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
            rb.gravityScale = gravityScale;
            float jumpforce = Mathf.Sqrt(jumpHeight * (Physics2D.gravity.y * rb.gravityScale) * -2) * rb.mass;
            rb.AddForce(Vector2.up * jumpforce , ForceMode2D.Impulse);

        }

        if (Input.GetButtonUp("Jump"))
        {
            rb.gravityScale = fallGravityScale;
        }
        if (IsGrounded())
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }
        if (!IsGrounded())
        {

            if (Mathf.Abs(rb.velocity.x) < speed)
            {

                rb.AddForce(Vector2.right * horizontal * speed * 1 / 5, ForceMode2D.Impulse);
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
