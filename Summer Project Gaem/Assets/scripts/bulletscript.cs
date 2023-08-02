using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletscript : MonoBehaviour
{
    public int dmg;
    public float speed;
    public MC_Script mc;
    public float dir;
    public float sd;
    private float timer;
    public float bullettime;
    private float _s;
    private float _sdt;

    void Start()
    {
        _s = speed;
        mc = GameObject.FindGameObjectWithTag("Player").GetComponent<MC_Script>();
    }


    void Update()
    {
        if (mc.hit)
        {
            mc.hit = false;
            
        }
        transform.position += Vector3.right * _s *dir* Time.deltaTime;
        timer += Time.deltaTime;
        if (timer >= bullettime)
        {
            Destroy(gameObject);
        }
        _sdt += Time.deltaTime;
        if (_sdt >= sd)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        mc.dmgtaken = dmg;
        mc.hit = true;
        Destroy(gameObject);
    }
}
