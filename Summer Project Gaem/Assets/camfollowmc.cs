using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camfollowmc : MonoBehaviour
{
    public Transform player;
    public float offset;
 
    void Start()
    {
        
    }

    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        offset = gameObject.transform.position.x - player.position.x;
        gameObject.transform.position.x = player.position.x + offset;
    }
}
