using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAttack : MonoBehaviour
{
    public static EnemyAttack Instance;
    [SerializeField] protected EnemyScriptableInfo Enemydamage;
    protected int Dmg;
    protected Transform player;
    Animator animator;
    public Rigidbody2D rb;
    [SerializeField] float check;
    [SerializeField] float movespeed ;
    [SerializeField] Transform pointatk;
  [SerializeField]  LayerMask mask;
    public float ScaleX;
    public float ScaleY;
    [SerializeField]public float DistanAttack=7f;


    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        Dmg=Enemydamage.Damage;
        player = GameObject.Find("player").transform;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        movespeed = 2;
    }

    // Update is called once per frame
    void Update()
    {
       
        float distan = Vector2.Distance(transform.position, player.position);
        if (HPController.instance.currenthp > 0)
        {
            if (distan < DistanAttack)
            {
                FollowPlayer();

                if (distan >= 1f)
                {
                    StopFollow();
                }
            }
        }
    }
    public void FollowPlayer()
    {

        if ((transform.position.x < player.transform.position.x) && HPController.instance.currenthp > 0)
        {
            rb.velocity = new Vector2(movespeed, 0);
            animator.SetBool("iswalk", false);
            transform.localScale = new Vector2(ScaleX, ScaleY);
        }
        else
        {
           rb.velocity = new Vector2(-movespeed, 0);
            animator.SetBool("iswalk", false);
            transform.localScale = new Vector2(-ScaleX, ScaleY);
        }
        

    }
    protected void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointatk.position, check);
    }
    private void  StopFollow()
    {
        rb.velocity = Vector2.zero;
        animator.SetTrigger("isatk");
    }
    public void AttackPlayer()
    {

        Collider2D[] enemy = Physics2D.OverlapCircleAll(pointatk.transform.position, check, mask);
        foreach (Collider2D var in enemy)
        {
            HPController.instance.TakeDamage(Dmg);
        }


    }
 
}
