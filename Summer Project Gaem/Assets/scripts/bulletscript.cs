using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletscript : MonoBehaviour
{
    public int dmg;
    public float speed;
    public MC_Script mc;
    public float dir;

    void Start()
    {
        mc = GameObject.FindGameObjectWithTag("Player").GetComponent<MC_Script>();
    }


    void Update()
    {
        if (mc.hit)
        {
            mc.hit = false;
            Destroy(gameObject);
        }
        transform.position += Vector3.right * speed *dir* Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        mc.dmgtaken = dmg;
        mc.hit = true;
    }
}
