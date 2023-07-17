using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Logicmain : MonoBehaviour
{
    public MC_Script mc;
    public vinedoorlogic vinedoor;
    public keyleaflogic keyleaf;
    public shitlogic shit;

    public List<bool> interactorder;

    public bool caninteract=false;
    public bool keyinteract=false;
    public bool vdoorinteract = false;
    public bool nokey = false;
    public bool dooropen;


    void Start()
    {
        mc = GameObject.FindGameObjectWithTag("Player").GetComponent<MC_Script>();

    }

    private void FixedUpdate()
    {
        vdoorinteract = vinedoor.ininteractzone;
        if (mc.doorinteract && mc.haskey == 0)
        {
            nokey = true;
        }
        if(mc.doorinteract&& mc.haskey > 0)
        {
            dooropen = true;
            mc.haskey -= 1;
        }


    }


    void Update()
    {
        
    }
}
