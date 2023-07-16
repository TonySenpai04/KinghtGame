using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    public static AnimationPlayer instance;
    private Animator animator;
    private bool isright;
    [SerializeField] private Transform groundcheck;
    [SerializeField] private LayerMask layer;
    [SerializeField] private bool isground;
    [SerializeField] private bool isSkill1 ;
    [SerializeField] private bool isDead;
    [SerializeField] public int Count=0;
    public bool isSkill2;
    public bool isSkill3;
    public bool isSkill4;
    public bool IsDead { get => isDead; set => isDead = value; }
    public Animator Animator { get => animator; set => animator = value; }
    public bool IsSkill1 { get => isSkill1; set => isSkill1 = value; }
    public AudioSource audioSource;
    void Start()
    {
        Vector3 localScale = transform.localScale;
        localScale.x = 1;
        localScale.y = 1;
        Animator = GetComponent<Animator>();
    }
    private void Awake()
    {
        instance = this;
        isright = true;
        instance = this;
        isDead = false;
    }
    void Update()
    {

        if (IsDead == false)
        {
            Isfactright();
            Walk();
        }
            Isdeadth();
    }
    private void FixedUpdate()
    {
        if (IsDead == false)
        {
            Jump();
            Skill1();
            Skill2();
            Skill3();
            Skill4();
        }

    }
    protected void Walk()
    {
        isground = Physics2D.OverlapCircle(groundcheck.position, 0.2f, layer);
        var move = InputManager.Instance.Move;
        if ((move == 1 || move == -1) && isground)
        {
            Animator.SetBool("runing", true);
            AudioPlayer.instance.Audio.enabled = true;
        }
        else
        {
            Animator.SetBool("runing", false);
            AudioPlayer.instance.Audio.enabled = false;
        }
        if (move > 0)
            isright = true;
        else if (move < 0)
            isright = false;

    }
    protected void Isfactright()
    {
        if (isright == true)
            transform.localScale = new Vector2(1, 1);
        else if (isright == false)
            transform.localScale = new Vector2(-1, 1);
    }
    protected void Jump()
    {
        isground = Physics2D.OverlapCircle(groundcheck.position, 0.2f, layer);
        if (InputManager.Instance.IsJump && isground)
        {
            audioSource.PlayOneShot(AudioPlayer.instance.jumpClip);
            Animator.SetTrigger("jumping");
        }

    }
    public bool IsAtk(int index)
    {
        return MPController.Instance.Currentmp >= AttackFunction.Instance.skillS0[index].ManaConsumption &&
             LevelSystem.Instance.level >= AttackFunction.Instance.skillS0[index].RequiredLevel;
    }
    public void Skill1()
    {
        if (InputManager.Instance.IsSkill1 && IsAtk(0) && isSkill1 == true )
        {
            audioSource.PlayOneShot( AudioPlayer.instance.AtkClip);
            Animator.SetTrigger("Skill1");
            CooldownSkill(0);
        }
    }
    protected void Isdeadth()
    {
        if (HPController.Instance.currenthp == 0)
        {
            Animator.SetTrigger("isdeath");
            if (Count <= 1)
            {
                audioSource.PlayOneShot(AudioPlayer.instance.deathClip);
                Count++;
            }
            IsDead = true;
            Animator.SetBool("Idle", false);
        }
        
    }
    public void Skill2()
    {  
        if (InputManager.Instance.IsSkill2 && IsAtk(1) && isSkill2==true)
        {
            audioSource.PlayOneShot(AudioPlayer.instance.AtkClip);
            Animator.SetTrigger("Skill2");
            CooldownSkill(1);
        }
    }
    public void Skill3()
    {
        if (InputManager.Instance.IsSkill3 && IsAtk(2) && isSkill3 == true)
        {
            audioSource.PlayOneShot(AudioPlayer.instance.AtkClip);
            Animator.SetTrigger("Skill3");
            CooldownSkill(2);
        }
    }
    public void Skill4()
    {
        if (InputManager.Instance.IsSkill4 && IsAtk(3) && isSkill4 == true)
        {
            audioSource.PlayOneShot(AudioPlayer.instance.AtkClip);
            Animator.SetTrigger("Skill4");
            CooldownSkill(3);
        }
    }
    public void CooldownSkill(int index)
    {
        if (Skill.Instance.time[index].IsUseSkill == true)
        {
            Skill.Instance.time[index].Currenttime += Skill.Instance.time[index].timeskill;
            Skill.Instance.time[index].IsUseSkill = false;
        }
    }

}

