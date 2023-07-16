using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold_Diamond : MonoBehaviour
{
    public static Gold_Diamond instance;
    [SerializeField]
    private float gold;
    [SerializeField]  private float diamond;

   
    public float Diamond { get => diamond; set => diamond = value; }
    public float Gold { get => gold; set => gold = value; }

    private void Start()
    {
        instance = this;
        Gold = PlayerData.Intance.characterData.Gold;
        diamond = PlayerData.Intance.characterData.Diamond;
    }
   

}
