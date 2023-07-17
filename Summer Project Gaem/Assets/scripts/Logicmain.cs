using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logicmain : MonoBehaviour
{
    public MC_Script mc;
    public vinedoorlogic vinedoor;
    public keyleaflogic keyleaf;
    void Start()
    {
        mc = GameObject.FindGameObjectWithTag("Player").GetComponent<MC_Script>();

    }

    private void FixedUpdate()
    {
        
    }


    void Update()
    {
        
    }
}
