using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[CreateAssetMenu(fileName ="Enemy",menuName ="enemy/Enemy")]
public class EnemyScriptableInfo : ScriptableObject
{
  
    // Start is called before the first frame update
    public float MaxHp;
    public int Damage;
    public int GoldDrop;
    public int MinGoldDrop;
    public int MaxGoldDrop;
    public int Exp;
    public int MinExp;
    public int MaxExp;

}
