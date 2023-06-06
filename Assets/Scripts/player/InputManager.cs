using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;
    private float move;
    public float Move { get => move; }
    public bool isSkill1 { get => IsSkill1; }
    public bool IsJump { get => Isjump; }
    public bool isSkill2 { get => IsSkill2; }

    private bool IsSkill2;
    private bool Isjump;
    private bool IsSkill1;
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
    }
    public void MovePlayer()
    {
        move = Input.GetAxis("Horizontal");
    }
    public void Skill1()
    {
        IsSkill1 = Input.GetKey(KeyCode.Alpha1);
    }
    public void Jump()
    {
        Isjump = Input.GetButton("Jump");
    }
    public void Skill2()
    {
        IsSkill2 = Input.GetKey(KeyCode.Alpha2);
    }
}
