using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioPlayer : MonoBehaviour
{
    public static AudioPlayer instance;
    public AudioSource Audio;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask layer;
    bool isground;
    [SerializeField] public AudioClip AtkClip;
    [SerializeField] public AudioClip jumpClip;
    [SerializeField] public AudioClip deathClip;
    public AudioClip levelUpSound;
    public AudioClip ActionSound;
    public AudioClip ClickBtnSound;
    public AudioClip JumpDown;
    void Start()
    {
        instance = this;
        Audio = GetComponent<AudioSource>();
        groundCheck = GameObject.Find("CheckGround").transform;
    }
}
