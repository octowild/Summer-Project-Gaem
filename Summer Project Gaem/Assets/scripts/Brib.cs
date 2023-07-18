using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brib : MonoBehaviour
{
    public Animator anim;
    public GameObject shit;
    public GameObject mc;
    public float offset;
    public float timebwshits;
    public Vector2 birbtrigrange;
    public float speed;
    public float flyheight;
    private float timer;
    private Vector3 move;
    private float xdiff;
    private bool flyhor;

    void Start()
    {
        mc = GameObject.FindGameObjectWithTag("Player");
    }


    void Update()
    {
        xdiff = transform.position.x - mc.transform.position.x;
        timer += Time.deltaTime;
        if (offset >= Mathf.Abs(transform.position.x - mc.transform.position.x)&&timer>=timebwshits)
        {
            Instantiate(shit, transform.position, transform.rotation);
            timer = 0;
        }
        

        if (birbtrigrange.x >= Mathf.Abs(transform.position.x - mc.transform.position.x)&& birbtrigrange.y >= Mathf.Abs(transform.position.y - mc.transform.position.y)&&!flyhor)
        {
            move = new Vector3(-1*Mathf.Sign(xdiff),1, 0);
            
        }
        transform.position += move;

        if (flyheight <= transform.position.y)
        {
            flyhor = true;
            move = new Vector3(-speed*Mathf.Sign(xdiff), 0, 0);
        }
            
        
        
        
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, new Vector3(birbtrigrange.x * 2, birbtrigrange.y * 2, 1));
    }
}
