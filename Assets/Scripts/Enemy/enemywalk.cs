using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class enemywalk : MonoBehaviour
{
    public static enemywalk instance;
 [SerializeField]   protected float movespeed = 2;
    protected bool isfactright = true;
    [SerializeField] protected Transform groundcheck;
    [SerializeField] protected float distance;
    [SerializeField] protected LayerMask layer;
    Animator animator;
    [SerializeField] protected Transform player;
    [SerializeField] protected float check;
    public float ScaleX;
    public float ScaleY;
    public float DistanWalk=7f;

    // Start is called before the first frame update
    void Start()
    {
        instance = this; 
        animator = GetComponent<Animator>();
        player = GameObject.Find("player").transform;
        check = 6;
      
    }

    // Update is called once per frame
    void Update()
    {
        
            player = GameObject.Find("player").transform;

            float distan = Vector2.Distance(transform.position, player.position);
            RaycastHit2D groundinfo = Physics2D.Raycast(groundcheck.position, Vector2.down, distance, layer);
            if (!groundinfo.collider)
            {
                Flip();
            }
            if (distan >= DistanWalk || HPController.Instance.currenthp == 0)
            {

                Walk();
            }

        
    }
    public void Flip()

    {

        isfactright = !isfactright;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Map")
        {
            Flip();
        }
    }
    private void Walk()
    {
        if (isfactright)
        {
            Vector3 localScale = transform.localScale;
            animator.SetBool("iswalk", true);
            transform.Translate(Vector2.right * movespeed * Time.deltaTime);
            localScale.x = ScaleX ;
            transform.localScale = localScale;
 

        }
        else
        {
            Vector3 localScale = transform.localScale;
            localScale.x = -ScaleX;
            transform.localScale = localScale;
            transform.Translate(Vector2.left * movespeed * Time.deltaTime);
            animator.SetBool("iswalk", true);
          
        }
    }
    

}
