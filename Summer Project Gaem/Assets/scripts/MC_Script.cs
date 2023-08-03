using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MC_Script : MonoBehaviour
{
    public int maxhp;
    public float movespeed;
    public float jumpstr;
    public float jumptime;
    public float airspeed;
    public Rigidbody2D mcrb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    public Animator anim;
    public keyleaflogic key;
    public Logicmain logic;
    public GameObject spawn;
    public SpriteRenderer mcsprite;
    private float sideinput;
    private bool isjumping;
    private float jumptimer;
    private bool faceingright=true;
    public int haskey;
    public bool mcinteract;
    public bool doorinteract;
    public bool hit;
    public int dmgtaken;
    public bool isded;
    public int c_hp;
    public float vinedmgtick;
    private float timer = 0;
    private bool grounded;
    private float airdirstorage;
    private bool decreaseairs;






    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<Logicmain>();
        spawn = GameObject.FindGameObjectWithTag("playerspawn");
        c_hp = maxhp;
    }

    private void FixedUpdate()
    {

        if (dmgtaken > 0) {
            StartCoroutine(flashred());
        }

        c_hp -= dmgtaken;
        dmgtaken = 0;
        if (c_hp <= 0)
        {
            isded = true;
        }

    }
    void Update()
    {
        grounded = IsGrounded();

        
        if (Input.GetButtonDown("Jump") && grounded&&!isded) //jump
        {
            StartCoroutine(jumpanim());
            isjumping = true;
            jumptimer = jumptime;
            mcrb.velocity = Vector2.up * jumpstr;

        }
        if (Input.GetButton("Jump") && isjumping&&!isded) //jumpmoar
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
        if (Input.GetButtonUp("Jump")) //nojump
        {
            isjumping = false;

        }
        if (grounded) //animstuff
        {
            anim.SetBool("_landing", true);

        }else anim.SetBool("_landing", false);

        if (!isded) //movement
        {
            sideinput = Input.GetAxisRaw("Horizontal");
        }
        else { sideinput = 0; } 

        if (sideinput != 0) //animstuff
        {
            anim.SetBool("_move", true);
        }else { anim.SetBool("_move", false); }

        if (grounded) {
            airdirstorage = sideinput;
        }

        if (sideinput!= airdirstorage) { decreaseairs = true; }
        if (decreaseairs) { mcrb.velocity = new Vector2(sideinput * airspeed, mcrb.velocity.y); }

        else {
            mcrb.velocity = new Vector2(sideinput * movespeed, mcrb.velocity.y);

        }
        if (grounded) { decreaseairs = false; }


        if (Input.GetButtonDown("Interact") && logic.vdoorinteract&&!isded)
        {
            anim.SetBool("_interact", true); 
            doorinteract = true;

        }
        
        if (Input.GetButtonDown("Interact") && key.ininteractzone && !isded)
        {
            anim.SetBool("_interact", true);
            haskey += 1;
            mcinteract = true;


        }
        if (Input.GetButtonUp("Interact"))
        {
            anim.SetBool("_interact", false);
            doorinteract = false;
            mcinteract = false;
        }

        if (sideinput>0 && !faceingright)
        {
            flip();
        }else if (sideinput < 0 && faceingright)
        {
            flip();
        }

    }
    
    private void OnCollisionStay2D(Collision2D collision)
    {
        timer += Time.deltaTime;
        if (collision.collider.tag == "hitbox"&&timer>=vinedmgtick)
        {
            dmgtaken = logic.vinedmg;
            timer =0;
        }
    }

    public IEnumerator flashred()
    {
        mcsprite.color = new Color32(255,100,96,255);
        yield return new WaitForSeconds(0.1f);
        mcsprite.color = Color.white;
    }
    public IEnumerator jumpanim()
    {
        anim.SetBool("_isjumping", true);
        yield return new WaitForSeconds(0.2f);
        anim.SetBool("_isjumping", false);
    }
    public void Respawn()
    {
        isded = false;
        c_hp = maxhp;
        transform.position = spawn.transform.position;
        logic.inputrespawn = true;
    }


    void flip()
    {
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
        faceingright = !faceingright;
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}