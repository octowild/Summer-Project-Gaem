using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camfollowmc : MonoBehaviour
{
    public GameObject player;
    public movement mcs;
    public Vector2 offset;
    public float speedfactor;


    void Start()
    {
        
    }

    void Update()
    {

        float camspeed = mcs.speed > speedfactor ? mcs.speed : speedfactor;
        if (Mathf.Abs(player.transform.position.x - transform.position.x) >= offset.x || Mathf.Abs(player.transform.position.y - transform.position.y) >= offset.y)
        {         
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z), camspeed * Time.deltaTime);
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, offset);
    }
}