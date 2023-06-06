using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Rigidbody2D rb;
    [SerializeField]  private float speed = 9;
    [SerializeField] private GameObject player;
  
    private void Start()
    {

        rb =player. GetComponent<Rigidbody2D>();
       
    }
    // Update is called once per frame
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
       
    }

    
}
