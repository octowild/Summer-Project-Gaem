using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vinedoorlogic : MonoBehaviour
{
    public Logicmain logic;
    public CapsuleCollider2D capcol;
    public CircleCollider2D circol;
    public bool ininteractzone;
    public string uitxt = "this is a door";

  

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<Logicmain>();
    }


    void Update()
    {
        
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
