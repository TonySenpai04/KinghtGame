using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefencePlayer : MonoBehaviour
{
    public static DefencePlayer Instance;
    
    public int Defense;
    public int DefenseClone;
    public bool Isuse;
    public bool CanX2;

    void Start()
    {
        Instance = this;
        Defense = 0;
        DefenseClone = 0;
        CanX2 = true;
        Isuse = false;
    }
    public void ItemDef()
    {
        if (UIDefense.Instance.time > 0)
        {
            Isuse = true;
            if (CanX2 == true)
            {
                Defense *= 2;
            }
            CanX2 = false;
        }
    }

}
