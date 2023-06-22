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
        Camerafollow();
        
    }
    protected void Camerafollow()
    {
        if ((player.transform.position.x < 52.0f && player.transform.position.x > -2f) && Loadmap.instance.isLoad == false)
        {
            Vector3 pos = transform.position;
            pos.x = player.position.x;
            pos.y = player.position.y;
            transform.position = pos;
        }
        else
        { if(Loadmap.instance.isLoad == true)
            {
                Vector3 pos = transform.position;
                pos.x = -2.7f;
                pos.y = player.position.y;
                transform.position = pos;
                Loadmap.instance.isLoad = false;
            }
           
        }

    }
   
}
