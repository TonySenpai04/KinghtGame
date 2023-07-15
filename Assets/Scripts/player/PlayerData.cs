using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData Intance;
    public ChacracterData characterData;
    void Awake()
    {
        Intance = this;
    }


}
