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
    public float despawndis=100;
    public float animtimer;
    private float timer;
    private float _timeranim;
    private Vector3 move;
    private float xdiff;
    private bool flyhor;
    private bool trig;
    private bool faceleft;

    void Start()
    {
        mc = GameObject.FindGameObjectWithTag("Player");
    }



    void FixedUpdate()
    {
        if (!flyhor)
        {
            xdiff = transform.position.x - mc.transform.position.x;
        }
        
        timer += Time.deltaTime;
        if (offset >= Mathf.Abs(transform.position.x - mc.transform.position.x)&&timer>=timebwshits)
        {
            Instantiate(shit, transform.position, transform.rotation);
            timer = 0;
        }

        _timeranim += Time.deltaTime;
        if (birbtrigrange.x >= Mathf.Abs(transform.position.x - mc.transform.position.x)&& birbtrigrange.y >= Mathf.Abs(transform.position.y - mc.transform.position.y)&&!flyhor)
        {
            if ( _timeranim >= animtimer) {
                move = new Vector3(-0.1f * Mathf.Sign(xdiff), 0.1f, 0);
                trig = true;
            }
            anim.SetBool("is_flying", true);
        }
        transform.position += move;

        if (flyheight <= transform.position.y&&trig)
        {
            flyhor = true;
            move = new Vector3(-speed*Mathf.Sign(xdiff), 0, 0);
        }
            
        if (Mathf.Abs(transform.position.x - mc.transform.position.x)>=despawndis)
        {
            Destroy(gameObject);
        }

        if(xdiff>0 && faceleft)
        {
            flip();
        }else if (xdiff < 0 && !faceleft)
        {
            flip();
        }
        
        
        
    }

    void flip()
    {
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
        faceleft = !faceleft;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, new Vector3(birbtrigrange.x * 2, birbtrigrange.y * 2, 1));        
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, flyheight,1));
        //Gizmos.DrawWireCube(transform.position, new Vector3(despawndis * 2, 0, 1));
    }
}
