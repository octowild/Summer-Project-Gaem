using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class peashooter : MonoBehaviour
{
    public GameObject mc;
    public GameObject bullet;
    public bulletscript bs;
    public float shootspeed;
    private float timer;
    public Vector2 trigrange;
    public Animator anim;
    public float _animtime;
    private float xdiff;
    private float ydiff;
    private bool faceleft;
    private float _animt ;
    private Vector3 _bspawn;
    private float _boffset=-0.855f;

    void Start()
    {
        mc = GameObject.FindGameObjectWithTag("Player");
    }


    void FixedUpdate()
    {
        xdiff = mc.transform.position.x - transform.position.x;
        ydiff = mc.transform.position.y - transform.position.y;
        anim.SetBool("atk", false);
        timer += Time.deltaTime;
        if (trigrange.x>=Mathf.Abs(xdiff)&& trigrange.y >= Mathf.Abs(ydiff) && timer >= shootspeed)
        {

            _animt += Time.deltaTime;
            anim.SetBool("atk", true);
            if (_animt>=_animtime)
            {
                _bspawn = transform.position + new Vector3(_boffset, 0, 0);

                GameObject shotbullet = Instantiate(bullet, _bspawn, transform.rotation);
                shotbullet.GetComponent<bulletscript>().dir = Mathf.Sign(xdiff);
                timer = 0;
                _animt = 0;

            }
        }

        if (xdiff > 0 && !faceleft)
        {
            flip();
            _boffset *= -1;
            bs._runflip = true;

        }
        else if (xdiff < 0 && faceleft)
        {
            flip();
            _boffset *= -1;
            bs._runflip = false;

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
        Gizmos.DrawWireCube(transform.position, new Vector3(trigrange.x * 2, trigrange.y * 2, 1));
    }
}
