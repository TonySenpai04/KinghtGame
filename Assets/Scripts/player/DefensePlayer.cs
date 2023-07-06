using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefencePlayer : MonoBehaviour
{
    public static DefencePlayer Instance;
    
    public int Defense;
    void Start()
    {
        Instance = this;
        Defense = 0;
    }
   
}
