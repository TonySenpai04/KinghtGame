using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check : MonoBehaviour
{
 //private  enemywalk checkgr;
    // Start is called before the first frame update
    void Start()
    {
      // checkgr=GetComponent<enemywalk>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            enemywalk.instance.Flip();
            //checkgr.flip();
        }
    }
}
