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

    void Start()
    {
        mc = GameObject.FindGameObjectWithTag("Player");
    }


    void Update()
    {
        timer += Time.deltaTime;
        if (offset >= Mathf.Abs(transform.position.x - mc.transform.position.x)&&timer>=timebwshits)
        {
            Instantiate(shit, transform.position, transform.rotation);
            timer = 0;
        }
        

        if (birbtrigrange.x >= Mathf.Abs(transform.position.x - mc.transform.position.x)&& birbtrigrange.y >= Mathf.Abs(transform.position.y - mc.transform.position.y))
        {
            move = new Vector3(5, 5, 0);
            
        }
        transform.position += move;

        if (flyheight <= transform.position.y)
        {
            move = new Vector3(speed, 0, 0);
        }
            
        
        
        
        
    }
}
