using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 9;
    [SerializeField] private GameObject player;
    private void Start()
    {
        rb =player. GetComponent<Rigidbody2D>();
        float XPos = PlayerData.Intance.characterData.XPos;
        float YPos = PlayerData.Intance.characterData.YPos;
        Vector3 pos = CameraFollowPlayer.instance.gameObject.transform.position;
        player.transform.position = new Vector3(XPos, YPos, transform.position.z);
        if (XPos < 52.0f && XPos > -2f)
        {
            pos.x = XPos;
            pos.y = YPos;
            CameraFollowPlayer.instance.gameObject.transform.position = pos;
        }
        else if(XPos < -2f)
        {
            pos.x = -2.7f;
            pos.y = YPos;
            CameraFollowPlayer.instance.gameObject.transform.position = pos;
        }
        else if(XPos > 52.0f)
        {
            pos.x = 51f;
            pos.y = YPos;
            CameraFollowPlayer.instance.gameObject.transform.position = pos;
        }
        
    }
    void Update()
    {
        Move();
        
    }
    protected void Move()
    {

        var move = InputManager.Instance.Move;
        if (AnimationPlayer.instance.IsDead==false)
        {
            rb.velocity = new Vector2(move * speed, rb.velocity.y);
        }
        PlayerPrefs.SetFloat("XPosition",player.transform.position.x);
        PlayerPrefs.SetFloat("YPosition", player.transform.position.y);
        PlayerData.Intance.characterData.XPos=player.transform.position.x;
        PlayerData.Intance.characterData.YPos = player.transform.position.y;


    }

    
}
