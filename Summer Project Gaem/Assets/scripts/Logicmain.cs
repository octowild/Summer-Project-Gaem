using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrayTypes : MonoBehaviour
{
    public ItemStruct[] structItems;
}
[System.Serializable]
public struct ItemStruct
{
    public int value;
    public string itemName;
}
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


    void Start()
    {
        mc = GameObject.FindGameObjectWithTag("Player").GetComponent<MC_Script>();

    }

    private void FixedUpdate()
    {
        keyinteract = keyleaf.ininteractzone;
        vdoorinteract = vinedoor.ininteractzone;

        if (mc.mcinteracts)
        {

        }
    }


    void Update()
    {
        
    }
}
