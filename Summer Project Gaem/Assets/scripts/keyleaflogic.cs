using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyleaflogic : MonoBehaviour
{
    public Logicmain logic;
    public MC_Script mc;
    public bool ininteractzone;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<Logicmain>();
        mc = GameObject.FindGameObjectWithTag("Player").GetComponent<MC_Script>();
    }

   
    void LateUpdate()
    {
        if (mc.mcinteract)
        {
            Destroy(gameObject);
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
