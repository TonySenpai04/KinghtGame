using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    public static Effect Instance;
    [SerializeField] private Transform Blueeffect;
    [SerializeField] private Transform Violeteffect;
    [SerializeField] private Transform Yelloweffect;
    [SerializeField] private Transform Whiteffect;
    public GameObject Hiteffct;
    void Start()
    {
        Instance=this;
        Hiteffct.gameObject.SetActive(false);
        Blueeffect.gameObject.SetActive(false);
        Violeteffect.gameObject.SetActive(false);
        Yelloweffect.gameObject.SetActive(false);
        Whiteffect.gameObject.SetActive(false);

    }
    void Update()
    {
        ActiveEffect();
    }
    protected void ActiveEffect()
    {
        if (LevelSystem.Instance.level >= 10)
        {
            Yelloweffect.gameObject.SetActive(true);
        }
        if (LevelSystem.Instance.level >= 15)
        {
            Yelloweffect.gameObject.SetActive(false);
            Violeteffect.gameObject.SetActive(true);
           
        }
        if(LevelSystem.Instance.level >= 20)
        {
           Blueeffect.gameObject.SetActive(true);
            Violeteffect.gameObject.SetActive(false);
        }
        if (LevelSystem.Instance.level >= 25)
        {
            Blueeffect.gameObject.SetActive(false);
            Whiteffect.gameObject.SetActive(true);

        }
    }
    public void HitEffect(Transform Position)
    {
        Hiteffct.transform.position = Position.position;
        Hiteffct.gameObject.SetActive(true);
        Invoke("EnaableHitEffect", 0.5f);
    }
    public void EnaableHitEffect()
    {
        Hiteffct.gameObject.SetActive(false);
    }
}
