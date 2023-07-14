using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private float horizontal;
    public float speed = 8f;
    [SerializeField] private float jumpHeight = 5f;
    private bool isFacingRight = true;
    private float timer;
    [SerializeField] private float mxtime = 1f;
    [SerializeField] private float trshldOne = 0.7f;
    [SerializeField] private float trshldTwo = 0.3f;
    private bool startTimer;
    //private bool jumping = false;
    //private float buttonPressedTime;
    //private Vector2 maxvelocity;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] float gravityScale = 5f;
    [SerializeField] float fallGravityScale = 15f;
    //[SerializeField] float buttonpressWindow;

    private void Awake()
    {
        timer = mxtime;
    }
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.gravityScale = gravityScale;
            startTimer = true;

            //Debug.Log(jumpforce);
        }

        if (startTimer)
        {
            timer -= Time.deltaTime;
        }

        //Debug.Log(rb.transform.position.y);

        if (rb.velocity.y > 0)
        {
            rb.gravityScale = gravityScale;
        }
        else
        {
            rb.gravityScale = fallGravityScale;
            //jumping = false;
        }

        if (Input.GetButtonUp("Jump") && timer > trshldOne && IsGrounded())
        {
            float jumpforce = Mathf.Sqrt(jumpHeight * (Physics2D.gravity.y * rb.gravityScale) * -2) * rb.mass;
            rb.AddForce(Vector2.up * jumpforce * 1 / 3, ForceMode2D.Impulse);
            rb.gravityScale = fallGravityScale;
            timer = mxtime;
            startTimer = false;
        }
        if (Input.GetButtonUp("Jump") && timer > trshldTwo && timer < trshldOne && IsGrounded())
        {
            float jumpforce = Mathf.Sqrt(jumpHeight * (Physics2D.gravity.y * rb.gravityScale) * -2) * rb.mass;
            rb.AddForce(Vector2.up * jumpforce * 2 / 3, ForceMode2D.Impulse);
            rb.gravityScale = fallGravityScale;
            timer = mxtime;
            startTimer = false;
        }
        if (Input.GetButtonUp("Jump") && timer < trshldTwo && timer >=0 && IsGrounded())
        {
            float jumpforce = Mathf.Sqrt(jumpHeight * (Physics2D.gravity.y * rb.gravityScale) * -2) * rb.mass;
            rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
            rb.gravityScale = fallGravityScale;
            timer = mxtime;
            startTimer = false; 
        }
        if (timer <= 0 && IsGrounded()) 
        {
            float jumpforce = Mathf.Sqrt(jumpHeight * (Physics2D.gravity.y * rb.gravityScale) * -2) * rb.mass;
            rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
            rb.gravityScale = fallGravityScale;
            timer = mxtime;
            startTimer = false;
        }

        //if (jumping)
        {
            //buttonPressedTime += Time.deltaTime;

            //if (buttonPressedTime < buttonpressWindow && Input.GetKeyUp("Jump"))
            {
                //rb.gravityScale = fallGravityScale;
            }

        }

        //if (Input.GetButtonUp("Jump") && rb.velocity.y >0f)
        {
          //  rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    private void FixedUpdate() 
    {
        if (IsGrounded() && startTimer == false)
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
