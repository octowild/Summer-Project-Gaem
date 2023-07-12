using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camfollowmc : MonoBehaviour
{
    public Rigidbody2D player;
    public Rigidbody2D rb;
    public Vector3 offset=new Vector3(0,0,-10);
    public bool istrig = false;
    public float speed;
 
    void Start()
    {
        
    }

    void Update()
    {
        if (istrig)
        {
            rb.velocity = player.velocity;
            //gameObject.transform.position = player.position + offset;
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        istrig = true;
       // offset = gameObject.transform.position - player.position;
       // offset = new Vector3(offset.x, 0, -10);
        
    }
    private void OnTriggerExit2D(Collider2D Collision)
    {
        istrig = false;
    }
}
