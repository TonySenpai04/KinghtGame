using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;
    private float move;
    public float Move { get => move; }
    public bool IsSkill1 { get => isSkill1; set => isSkill1 = value; }
    public bool IsJump { get => Isjump; }
    public bool IsSkill2 { get => isSkill2; }
    public bool IsSkill3 { get => isSkill3;}

    private bool isSkill3;
    private bool isSkill2;
    private bool Isjump;
    private bool isSkill1;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        Skill1();
        Jump();
        Skill2();
        Skill3();
    }
    public void MovePlayer()
    {
        move = Input.GetAxis("Horizontal");
    }
    public void Skill1()
    {
        isSkill1 = Input.GetKey(KeyCode.Alpha1);
    }
    public void Jump()
    {
        Isjump = Input.GetButton("Jump");
    }
    public void Skill2()
    {
        isSkill2 = Input.GetKey(KeyCode.Alpha2);
    }
    public void Skill3()
    {
        isSkill3 = Input.GetKey(KeyCode.Alpha3);
    }
}
