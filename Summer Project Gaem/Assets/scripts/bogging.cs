using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bogging : MonoBehaviour
{

    public float speeddec;
    public float jumpdec;
    public int dmg;
    public float inttimer;
    public float ticktimer;
    public MC_Script mc;
    public bool boged;
    private float _tint;
    private float _ttick;


    void Start()
    {
        mc = GameObject.FindGameObjectWithTag("Player").GetComponent<MC_Script>();
    }


    void Update()
    {
        if (boged)
        {
            _tint += Time.deltaTime;
            _ttick += Time.deltaTime;
        }
        if (_tint >= inttimer&&_ttick>=ticktimer)
        {
            mc.dmgtaken += dmg;
            _ttick = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        boged = true;
        mc.movespeed /= speeddec;
        mc.jumpstr /= jumpdec;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        boged = false;
        mc.movespeed *= speeddec;
        mc.jumpstr *= jumpdec;
        _tint = 0;
    }
}
