using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class SkillS0 : ScriptableObject
{
    [field: SerializeField] public Sprite Icon;
    [field: SerializeField] public string Name;
    [field: SerializeField] public float CooldownTime;
    [field: SerializeField] public int RequiredLevel;
    [field: SerializeField] public float DmgAdd;
    [field: SerializeField] public int ManaConsumption;
    [field: SerializeField] public int LevelSkill { get; set; } = 1;
    [field: SerializeField] public float IncreasesWithLevel;
    [field: SerializeField] public int MaxLevelSkill;

}
