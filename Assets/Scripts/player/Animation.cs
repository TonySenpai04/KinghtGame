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
    public bool IsDead { get => isDead; set => isDead = value; }
    public Animator Animator { get => animator; set => animator = value; }
    public bool IsSkill1 { get => isSkill1; set => isSkill1 = value; }

   
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
            Run();
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
            
        }

    }
    protected void Run()
    {
        isground = Physics2D.OverlapCircle(groundcheck.position, 0.2f, layer);
        var move = InputManager.Instance.Move;

        if ((move == 1 || move == -1) && isground)
        {
            Animator.SetBool("runing", true);

        }
        else
        {
            Animator.SetBool("runing", false);
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
            AudioSource.PlayClipAtPoint(AudioPlayer.instance.jumpClip, transform.position);
            Animator.SetTrigger("jumping");
        }

    }


    public void Skill1()
    {
        
        if (InputManager.Instance.IsSkill1 && MPController.Instance.Currentmp >= 1f && isSkill1 == true )
        {  
            AudioSource.PlayClipAtPoint(AudioPlayer.instance.AtkClip, transform.position);
            Animator.SetTrigger("Skill1");
            if (Skill.Instance.time[0].Isuse1 == true)
            {
                Skill.Instance.time[0].Currenttime += Skill.Instance.time[0].timeskill;
                Skill.Instance.time[0].Isuse1 = false;
            }
        }
    }
    protected void Isdeadth()
    {
        if (HPController.Instance.currenthp == 0)
        {
            Animator.SetTrigger("isdeath");
            if (Count <= 1)
            {
                AudioSource.PlayClipAtPoint(AudioPlayer.instance.deathClip, transform.position, 1);
                Count++;
            }
            IsDead = true;
            Animator.SetBool("Idle", false);
        }
        
    }
    public void Skill2()
    {
        if (InputManager.Instance.IsSkill2 && MPController.Instance.Currentmp >= 2 && LevelSystem.Instance.level >= 3
            && isSkill2==true)
        {
            Animator.SetTrigger("Skill2");
            if (Skill.Instance.time[1].Isuse1 == true)
            {
                Skill.Instance.time[1].Currenttime += Skill.Instance.time[1].timeskill;
                Skill.Instance.time[1].Isuse1 = false;
            }
        }
    }
    public void Skill3()
    {
        if (InputManager.Instance.IsSkill3 && MPController.Instance.Currentmp >= 12 && LevelSystem.Instance.level >= 5
            && isSkill3 == true)
        {
            Animator.SetTrigger("Skill3");
            if (Skill.Instance.time[2].Isuse1 == true)
            {
                Skill.Instance.time[2].Currenttime += Skill.Instance.time[2].timeskill;
                Skill.Instance.time[2].Isuse1 = false;
            }
        }
    }

}

