using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class Logicmain : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    public MC_Script mc;
    public vinedoorlogic vinedoor;
    public keyleaflogic keyleaf;
    public shitlogic shit;
    public TextMesh txt;
    public RawImage hrt;

    public int vinedmg = 1;

    public bool caninteract=false;
    public bool keyinteract=false;
    public bool vdoorinteract = false;
    public bool nokey = false;
    public bool dooropen;
    public bool inputrespawn;

    public Image[] hrts;
    public Animator hrtanim;
    public Animator keyiconanim;
    public TMP_Text keyno;

    void Start()
    {
        mc = GameObject.FindGameObjectWithTag("Player").GetComponent<MC_Script>();
        vinedoor = GameObject.FindGameObjectWithTag("interact").GetComponent<vinedoorlogic>();

    }

    private void FixedUpdate()
    {

        for (int i = 0; i < hrts.Length; i++)
        {
            hrtanim = hrts[i].GetComponent<Animator>();
            if (i >= mc.c_hp)
            {
                hrtanim.SetBool("dmged", true);
            }
            else
            {
                hrtanim.SetBool("dmged", false);
            }
        }
    }


    void Update()
    {
        if (mc.haskey>0)
        {
            keyiconanim.SetBool("keyininv", true);
        }
        keyno.text="x"+mc.haskey.ToString();
        
        if (mc.doorinteract && mc.haskey == 0)
        {
            nokey = true;
        }
        if (mc.doorinteract && mc.haskey > 0)
        {
            dooropen = true;
            mc.haskey -= 1;
        }
        vdoorinteract = vinedoor.ininteractzone;

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
