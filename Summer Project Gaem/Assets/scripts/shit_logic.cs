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
    public float shittime;
    private float speed;
    public bool s_hit;
    private float shitgone = 2f;
    private float timer;
    private float _t;

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
            
        }
        if (timer >= shitgone)
        {
            Destroy(gameObject);
        }
        _t += Time.deltaTime;
        if (timer >= shittime)
        {
            Destroy(gameObject);
        }
        transform.position += Vector3.down * speed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        mc.dmgtaken = dmg;
        mc.hit = true;
        Destroy(gameObject);
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
    }
}
