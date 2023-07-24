using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OldAnimation : MonoBehaviour
{
    public static OldAnimation instance;
    protected Animator animator;
    protected bool isright;
    [SerializeField] protected Transform groundcheck;
    [SerializeField] protected LayerMask layer;
    [SerializeField] protected bool isground;
    [SerializeField] protected bool isSkill1;
    [SerializeField] protected bool isDead;
    [SerializeField] public int CountPlayAudio = 0;
    public int CountPlayAudioJumpDown = 0;
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
    protected virtual  void Walk()
    {

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
    protected virtual void Isfactright()
    {
        if (isright == true)
            transform.localScale = new Vector2(1, 1);
        else if (isright == false)
            transform.localScale = new Vector2(-1, 1);
    }
    protected virtual void Jump()
    {
        if (InputManager.Instance.IsJump && isground)
        {
            audioSource.PlayOneShot(AudioPlayer.instance.jumpClip);
            Animator.SetTrigger("jumping");
        }

    }
    public virtual bool IsAtk(int index)
    {
        return MPController.Instance.Currentmp >= AttackFunction.Instance.skillS0[index].ManaConsumption &&
             LevelSystem.Instance.level >= AttackFunction.Instance.skillS0[index].RequiredLevel;
    }
    public virtual void Skill1()
    {
        if (InputManager.Instance.IsSkill1 && IsAtk(0) && isSkill1 == true)
        {
            audioSource.PlayOneShot(AudioPlayer.instance.AtkClip);
            Animator.SetTrigger("Skill1");
            CooldownSkill(0);
        }
    }
    protected virtual void Isdeadth()
    {
        if (HPController.Instance.currenthp == 0)
        {
            Animator.SetTrigger("isdeath");
            if (CountPlayAudio <= 1)
            {
                audioSource.PlayOneShot(AudioPlayer.instance.deathClip);
                CountPlayAudio++;
            }
            IsDead = true;
            Animator.SetBool("Idle", false);
        }

    }
    public virtual void Skill2()
    {
        if (InputManager.Instance.IsSkill2 && IsAtk(1) && isSkill2 == true)
        {
            audioSource.PlayOneShot(AudioPlayer.instance.AtkClip);
            Animator.SetTrigger("Skill2");
            CooldownSkill(1);
        }
    }
    public virtual void Skill3()
    {
        if (InputManager.Instance.IsSkill3 && IsAtk(2) && isSkill3 == true)
        {
            audioSource.PlayOneShot(AudioPlayer.instance.AtkClip);
            Animator.SetTrigger("Skill3");
            CooldownSkill(2);
        }
    }
    public virtual void Skill4()
    {
        if (InputManager.Instance.IsSkill4 && IsAtk(3) && isSkill4 == true)
        {
            audioSource.PlayOneShot(AudioPlayer.instance.AtkClip);
            Animator.SetTrigger("Skill4");
            CooldownSkill(3);
        }
    }
    public virtual void CooldownSkill(int index)
    {
        if (Skill.Instance.time[index].IsUseSkill == true)
        {
            Skill.Instance.time[index].Currenttime += Skill.Instance.time[index].timeskill;
            Skill.Instance.time[index].IsUseSkill = false;
        }
    }
}
