using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camfollowmc : MonoBehaviour
{
    public GameObject player;
    public Logicmain logic;
    public GameObject spawn;
    //   public MC_Script mcs;
    //   public Rigidbody2D mcrb;
    public float speedfactor;
 //   public Vector2 offset;
  //  public float camspeed;
 //   private Vector2 threshold;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //       threshold = calthreshold();
    }
  
    void FixedUpdate()
    {
     //   camspeed = mcs.movespeed > speedfactor ? mcs.movespeed : speedfactor;
     //   if (Mathf.Abs(player.transform.position.x - transform.position.x) >= offset.x || Mathf.Abs(player.transform.position.y - transform.position.y) >= offset.y)
     //   {
     //       transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z), camspeed * Time.deltaTime);

     //   }

     //   Vector2 follow = player.transform.position;
  //      float xdiff = Vector2.Distance(Vector2.right * transform.position.x, Vector2.right * follow.x);
   //     float ydiff = Vector2.Distance(Vector2.up * transform.position.y, Vector2.up * follow.y);
  //      Vector3 newpos = transform.position;
  //      if (Mathf.Abs(xdiff) >= threshold.x)
  //      {
  //          newpos.x = follow.x;
  //      }
   //     if (Mathf.Abs(ydiff) >= threshold.y)
   //     {
    //        newpos.y = follow.y;
    //    }
    //    float movespeed = mcrb.velocity.magnitude > camspeed ? mcrb.velocity.magnitude : camspeed;
   //     transform.position = Vector3.MoveTowards(transform.position,newpos,movespeed*Time.deltaTime);

        Vector3 newpos=player.transform.position+new Vector3(0,0,transform.position.z);
        Vector3 smoothpos = Vector3.Lerp(transform.position,newpos,speedfactor*Time.deltaTime);
        transform.position = smoothpos;

        if (logic.inputrespawn)
        {
            transform.position=
        }
    }
 //   private Vector3 calthreshold()
  //  {
 //       Rect aspect = Camera.main.pixelRect;
 //       Vector2 t = new Vector2(Camera.main.orthographicSize * aspect.width / aspect.height, Camera.main.orthographicSize);
 //       t.x -= offset.x;
 //       t.y -= offset.y;
 //       return t;
  //  }
 //   private void OnDrawGizmos()
 //   {
 //       Gizmos.color = Color.yellow;
 //       Vector2 border = calthreshold();
  //      Gizmos.DrawWireCube(transform.position, new Vector3(border.x*2,border.y*2,1));
 //   }
}