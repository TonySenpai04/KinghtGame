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
    }
    public void loadMap()
    {
            player.transform.position = new Vector2(targetdoor.transform.position.x, targetdoor.transform.position.y);
        isLoad = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Player")
        {
            player.transform.position = new Vector2(targetdoor.transform.position.x, targetdoor.transform.position.y);
            isLoad = true;
        }
    }



}
