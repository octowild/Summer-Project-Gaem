using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MC_Script : MonoBehaviour
{
    public int maxhp;
    public float movespeed;
    public float jumpstr;
    public float jumptime;
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
        if(logic.inputrespawn)
        { 
            c_hp = maxhp;
            isded = false;
            transform.position = spawn.transform.position;
        }
    }
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded()&&!isded)
        {
            isjumping = true;
            jumptimer = jumptime;
            mcrb.velocity = Vector2.up * jumpstr;
        }
        if (Input.GetKey(KeyCode.Space) && isjumping&&!isded)
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
        if (!isded)
        {
            sideinput = Input.GetAxisRaw("Horizontal");
        } else { sideinput = 0; }
        if (sideinput != 0)
        {
            anim.SetBool("_move", true);
        }else { anim.SetBool("_move", false); }
        
        mcrb.velocity = new Vector2(sideinput * movespeed, mcrb.velocity.y);

        if (Input.GetKeyDown(KeyCode.E)&&key.ininteractzone&&!isded)
        {
            haskey += 1;
            mcinteract = true;
            
        }
        if (Input.GetKeyDown(KeyCode.E) && logic.vdoorinteract&&!isded)
        {
            doorinteract = true;
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            doorinteract = false;
            mcinteract = false;
        }

        if(sideinput>0 && !faceingright)
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
            Debug.Log("vine");
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