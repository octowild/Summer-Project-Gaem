using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camfollowmc : MonoBehaviour
{
    public GameObject player;
    public Vector2 offset;
    public float speedfactor;
    //private Vector2 threshold;

    void Start()
    {
        Debug.Log(Camera.main.orthographicSize);
    }

    void FixedUpdate()
    {
        Debug.Log(player.transform.position);
        Debug.Log(transform.position);

        if (Mathf.Abs(player.transform.position.x - transform.position.x) >= offset.x || Mathf.Abs(player.transform.position.y - transform.position.y) >= offset.y)
        {
            Debug.Log("triggered");
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z), speedfactor * Time.deltaTime);
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, offset);
    }
}