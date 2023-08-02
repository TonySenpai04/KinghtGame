using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSkills : MonoBehaviour
{
    public static DataSkills Intance;
    public List<SkillS0> SkillData;
    private void Awake()
    {
        Intance = this; 
    }
}
