using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bogging : MonoBehaviour
{
    public bool boged;
    public float speeddec;
    public float jumpdec;
    public MC_Script mc;

    
    void Start()
    {
        mc = GameObject.FindGameObjectWithTag("Player").GetComponent<MC_Script>();
    }


    void Update()
    {
        
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
    }
}
