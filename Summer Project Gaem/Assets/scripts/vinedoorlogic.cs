using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vinedoorlogic : MonoBehaviour
{
    public Logicmain logic;
    public CapsuleCollider2D capcol;
    public CircleCollider2D circol;
    public bool ininteractzone;
    public Animator anim;

  

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<Logicmain>();
    }


    void Update()
    {
        if(logic.dooropen)
        {
            anim.SetBool("isopen", true);
            capcol.enabled = false;
            circol.enabled = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        ininteractzone = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        ininteractzone = false;
    }


}
