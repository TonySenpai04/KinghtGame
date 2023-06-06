using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    public static follow instance;
   [SerializeField] public Transform player;
  
    void Start()
    {
        player = GameObject.Find("player").transform;
        instance = this;
    }

    // Update is called once per frame
    void Update()     
    {
        player = GameObject.Find("player").transform;
        if (Loadmap.instance.isLoad == true)
        {
            
           // if (player.transform.position.x < 0)
            //{
                Vector3 pos = transform.position;
                pos.x = -2.7f;
                pos.y = player.position.y;
                transform.position = pos;
                Loadmap.instance.isLoad = false;
           // }
            //else if(player.transform.position.x >40)
            //{
            //    Vector3 pos = transform.position;
            //    pos.x = 51f;
            //    pos.y = player.position.y;
            //    transform.position = pos;
            //    Loadmap.instance.isLoad = false;
            //}
            //pos.y = player.position.y;
            //transform.position = pos;
          //  Loadmap.instance.isLoad = false;
        }
        Camerafollow();
    }
    protected void Camerafollow()
    {
         if (player. transform.position.x < 52.0f && player.transform.position.x >-2f 
            
            )
           
        {
            Vector3 pos = transform.position;
            pos.x = player.position.x;
            pos.y = player.position.y;
            transform.position = pos;
        }
        else
        {
            Vector3 pos = transform.position;
            pos.y = player.position.y;
            transform.position = pos;
        }
        
    }
   
}
