using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shitlogic : MonoBehaviour
{
    public int dmg;
    public float fallspeed;
    public Animator anim;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    public MC_Script mc;
    public Logicmain logic;
    private float speed;
    public bool s_hit;
    private float shitgone = 2f;
    private float timer;

    void Start()
    {
        speed = fallspeed;
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<Logicmain>();
        mc = GameObject.FindGameObjectWithTag("Player").GetComponent<MC_Script>();
    }


    void Update()
    {
        
        if (IsGrounded())
        {
            speed = 0;
            anim.SetBool("splash",true);
            timer += Time.deltaTime;

        }
        if (mc.hit)
        {
            mc.hit = false;
            Destroy(gameObject);
        }
        if (timer >= shitgone)
        {
            Destroy(gameObject);
        }
        transform.position += Vector3.down * speed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("shit");
        mc.dmgtaken = dmg;
        mc.hit = true;
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
    }
}
