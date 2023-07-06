using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//[CreateAssetMenu]
public abstract  class Task : MonoBehaviour
{
    public int Quality;
    public string taskName;
    public bool isCompleted=false;
    public string Description;
    public abstract bool SetTask(Task task);
    public Task(string name)
    {
        taskName = name;
        isCompleted = false;
    }
    //[Serializable]
    //public class ModifierData
    //{
    //    public CharacterStatModifierSO statModifier;
    //    public float value;
    //}
}
