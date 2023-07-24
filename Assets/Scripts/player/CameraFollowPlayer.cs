using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public static CameraFollowPlayer instance;
    public Transform player;
  
    void Start()
    {
        player = GameObject.Find("player").transform;
        instance = this;
    }

    void Update()     
    {
        player = GameObject.Find("player").transform;
        Camerafollow();
        
    }
    protected void Camerafollow()
    {
        if (player.transform.position.x < 52.0f && player.transform.position.x > -2f)
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
