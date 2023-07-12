using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camfollowmc : MonoBehaviour
{
    public Transform player;
    public Vector3 offset=new Vector3(0,0,-10);
    public bool istrig = false;
 
    void Start()
    {
        
    }

    void Update()
    {
        if (istrig)
        {
            gameObject.transform.position = player.position + offset;
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        istrig = true;
        offset = gameObject.transform.position - player.position;
        offset = new Vector3(offset.x, 0, -10);
        
    }
    private void OnTriggerExit2D(Collider2D Collision)
    {
        istrig = false;
    }
}
