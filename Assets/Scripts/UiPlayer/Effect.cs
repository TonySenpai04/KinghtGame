using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    [SerializeField] private Transform Blueeffect;
    [SerializeField] private Transform Violeteffect;

    [SerializeField] private Transform Yelloweffect;
    [SerializeField] private Transform Whiteffect;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
       
        Blueeffect.gameObject.SetActive(false);
        Violeteffect.gameObject.SetActive(false);
        Yelloweffect.gameObject.SetActive(false);
        Whiteffect.gameObject.SetActive(false);

    }

    // Update is called once per frame
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
}
