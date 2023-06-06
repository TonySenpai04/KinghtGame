using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGParallax : MonoBehaviour
{
    //[SerializeField]private float Speed;
    //[SerializeField] private float targetRepeat;


    [SerializeField]
    private float ScrollSpeed;
    [SerializeField] private Renderer renderer;
    [SerializeField]
    private Vector2 savedOffset;
    void Start()
    {
        renderer=GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Mathf.Repeat(ScrollSpeed * Time.time, 1);
        Vector2 offset = new Vector2(x, 0);
        renderer.sharedMaterial.SetTextureOffset("_MainTex", offset);
        //transform.position += new Vector3(-Speed * Time.deltaTime, 0);
        //if(transform.position.x < -targetRepeat)
        //{
        //    transform.position=new Vector3(targetRepeat, transform.position.y);
        //}
    }
}
