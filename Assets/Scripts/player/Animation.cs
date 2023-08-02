using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnimationPlayer : OldAnimation
{
    public static new AnimationPlayer instance;
    public string CurrentState;
    public string Player_idle = "_idle";
    public string Player_walk = "walk";
    public string Player_Jump = "jump";
    public string Player_Skill1 = "Skill1";
    public string Player_Skill2 = "Skill2";
    public string Player_Skill3 = "Skill3";
    public string Player_Skill4 = "Skill4";
    public string Player_Death = "Death";
    public bool IsDown;
    void Start()
    {
        Animator = GetComponent<Animator>();
    }
    private void Awake()
    {
        instance = this;
        isright = true;
        instance = this;
        isDead = false;
    }
    public void ChangeIdle()
    {
        ChangeAnimationState(Player_idle);
    }
    void Update()
    {
        isground = Physics2D.OverlapCircle(groundcheck.position, 0.2f, layer);
        if (IsDead == false)
        {
            Isfactright();
            Walk();
            JumpDown();

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
    public void ChangeAnimationState(string State)
    {
        if (CurrentState == State) {
            return;
        }
            animator.Play(State);
            CurrentState = State;
    }
    public void JumpDown()
    {
        if (isground == false && IsDown)
        {
            if (CountPlayAudioJumpDown <= 1)
            {
                ChangeAnimationState("Jumpdown");
                audioSource.PlayOneShot(AudioPlayer.instance.JumpDown);
                CountPlayAudioJumpDown++;
            }
        }
        else 
        {
            CountPlayAudioJumpDown =0;
        }
    }
    protected override void Walk()
    {
        var move = InputManager.Instance.Move;
        if (isground )
        {
            if (move !=0)
            {
                ChangeAnimationState(Player_walk);
                AudioPlayer.instance.Audio.enabled = true;
            }
            else 
            {
                ChangeAnimationState(Player_idle);
                AudioPlayer.instance.Audio.enabled = false;
            }
        }
        else
        {
            AudioPlayer.instance.Audio.enabled = false;
        }
        if (move > 0)
            isright = true;
        else if (move < 0)
            isright = false;

    }
    protected override void Isfactright()
    {
        if (isright == true)
            transform.localScale = new Vector2(1, 1);
        else if (isright == false)
            transform.localScale = new Vector2(-1, 1);
    }
    protected override void Jump()
    {
        if (InputManager.Instance.IsJump && isground)
        {
            audioSource.PlayOneShot(AudioPlayer.instance.jumpClip);
            AudioPlayer.instance.Audio.enabled = false;
            ChangeAnimationState(Player_Jump);
        }

    }

    public override bool IsAtk(int index)
    {
        return MPController.Instance.Currentmp >= AttackFunction.Instance.skillS0[index].ManaConsumption &&
             LevelSystem.Instance.level >= AttackFunction.Instance.skillS0[index].RequiredLevel;
    }
    public override void Skill1()
    {
        var Skill1 = InputManager.Instance.IsSkill1;
        if (Skill1 && IsAtk(0) && isSkill1)
        {
            ChangeAnimationState(Player_Skill1);
            audioSource.PlayOneShot(AudioPlayer.instance.AtkClip);
            CooldownSkill(0);
        }
    }
    protected override void Isdeadth()
    {
        if (HPController.Instance.currenthp == 0)
        {
            ChangeAnimationState(Player_Death); 
            if (CountPlayAudio <= 1)
            {
                audioSource.PlayOneShot(AudioPlayer.instance.deathClip);
                CountPlayAudio++;
            }
            IsDead = true;
            return;
        }
        else
        {
            IsDead = false;
            CountPlayAudio = 0;
        }

    }
    public override void Skill2()
    {
        var Skill2 = InputManager.Instance.IsSkill2;
        if (Skill2 && IsAtk(1) && isSkill2)
        {
            audioSource.PlayOneShot(AudioPlayer.instance.AtkClip);
            ChangeAnimationState(Player_Skill2);
            CooldownSkill(1);
        }

    }
    public override void Skill3()
    {

        var Skill3 = InputManager.Instance.IsSkill3;
        if (Skill3  && IsAtk(2) && isSkill3 )
        {
            audioSource.PlayOneShot(AudioPlayer.instance.AtkClip);
            ChangeAnimationState(Player_Skill3);
            CooldownSkill(2);
        }
    }
    public override void Skill4()
    {
        var Skill4 = InputManager.Instance.IsSkill4;
        if (Skill4 && IsAtk(3) && isSkill4 == true)
        {
            audioSource.PlayOneShot(AudioPlayer.instance.AtkClip);
            ChangeAnimationState(Player_Skill4);
            CooldownSkill(3);
        }
    }
    public override void CooldownSkill(int index)
    {
        if (Skill.Instance.time[index].IsUseSkill == true)
        {
            Skill.Instance.time[index].Currenttime += Skill.Instance.time[index].timeskill;
            Skill.Instance.time[index].IsUseSkill = false;
        }
    }

}

