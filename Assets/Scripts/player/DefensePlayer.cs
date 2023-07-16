using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefencePlayer : MonoBehaviour
{
    public static DefencePlayer Instance;
    public int Defense;
    public int DefenseClone;
    public bool IsTonic;
    public bool CanX2;

    void Start()
    {
        Instance = this;
        Defense = PlayerData.Intance.characterData.Defense;
        DefenseClone = 0;
        CanX2 = true;
        IsTonic = false;
    }
    public void ItemDef()
    {
        if (UIDefense.Instance.time > 0)
        {
            IsTonic = true;
            if (CanX2 == true)
            {
                Defense *= 2;
            }
            CanX2 = false;
        }
    }

}
