using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loadmap : MonoBehaviour
{
    public static Loadmap instance;
    [SerializeField] protected Transform targetdoor;
    protected Transform player;
    //[SerializeField] Animator Transition;
    public bool isLoad;

  
  
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        isLoad = false;
        player = GameObject.Find("player").transform;
    }
    private void Update()
    {
        player = GameObject.Find("player").transform;
       // Debug.Log(isLoad.ToString());
     
    }

    public void loadMap()
    {
        player.transform.position = new Vector2(targetdoor.transform.position.x, targetdoor.transform.position.y);
        isLoad = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            isLoad = true;
            player.transform.position = new Vector2(targetdoor.transform.position.x, targetdoor.transform.position.y);
            Vector3 pos = follow.instance.transform.position;
            if (player.transform.position.x < 0)
            {
                pos.x = -2.7f;
                pos.y = player.position.y;
                follow.instance.transform.position = pos;
            }
            else
            {
                pos.x = 51f;
                pos.y = player.position.y;
                follow.instance.transform.position = pos;
            }
        }
        
    }



}
