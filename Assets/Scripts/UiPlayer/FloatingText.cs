using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float destroytime = 1f;
    [SerializeField] private Vector3 offset=new Vector3(0,2,0);
     Transform player;
     Animator anim;
    

    void Start()
    {
        Destroy(gameObject,destroytime);
        transform.localPosition += offset;
        anim=GetComponent<Animator>();
        player = GameObject.Find("player").transform;
        if (player.localScale.x < 0)
        {

            anim.SetBool("isright", true);
        }
        else
        {

            anim.SetBool("isright", false);
        }
    }
    private void Update()
    {
        if (player.localScale.x < 0)
        {

            anim.SetBool("isright", true);
        }
        else
        {

            anim.SetBool("isright", false);
        }
    }


}
