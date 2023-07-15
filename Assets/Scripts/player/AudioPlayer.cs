using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioPlayer : MonoBehaviour
{
    public static AudioPlayer instance;
    public AudioSource AudioWalk;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask layer;
    bool isground;
    [SerializeField] public AudioClip AtkClip;
    [SerializeField] public AudioClip jumpClip;
    [SerializeField] public AudioClip deathClip;
    public AudioClip levelUpSound;
    public AudioClip ActionSound;
    void Start()
    {
        instance = this;
        AudioWalk = GetComponent<AudioSource>();
        groundCheck = GameObject.Find("CheckGround").transform;

    }
    void Update()
    {

        Audiowalk();
    }

    public void Audiowalk()
    {
        isground = Physics2D.OverlapCircle(groundCheck.position, 0.2f, layer);
        var move = Input.GetAxis("Horizontal");
        if ((move == 1 || move == -1)&&isground && AnimationPlayer.instance.IsDead==false)
        {
            AudioWalk.enabled = true;
        }
        else
        {
            AudioWalk.enabled = false;
        }
    }
   
    
}
