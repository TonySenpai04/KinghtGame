using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioSound : MonoBehaviour
{
    public AudioSource AudioWalk;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask layer;
    bool isground;

    void Start()
    {
        AudioWalk = GetComponent<AudioSource>();
        groundCheck = GameObject.Find("CheckGround").transform;

    }
    private void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        AudioWalk.Pause();
        Audiowalk();
    }

    public void Audiowalk()
    {
        isground = Physics2D.OverlapCircle(groundCheck.position, 0.2f, layer);
        var move = Input.GetAxis("Horizontal");
        if ((move == 1 || move == -1)&&isground && AnimationPlayer.instance.IsDead==false)
        {
            AudioWalk.Play();
        }
        else
        {
            AudioWalk.Pause();
        }
    }
   
    
}
