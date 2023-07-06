using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
[CreateAssetMenu]
public class TaskSO : ScriptableObject
{
    [field: SerializeField] public missionType test;
    [field: SerializeField] public string Description;
    public bool Set(Task task)
    {
        if (test == missionType.Online)
        {
            if (task.Quality > 10)
            {
                return true;
            }else { return false; }
        }
        else
        {
            if (task.Quality > 20)
            {
                return true;
            }
            else { return false; }
        }
    }

}
public enum missionType { 
     Online,Farm

}


