using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    [SerializeField] private Transform effect;
    [SerializeField] private Transform effect2;

    [SerializeField] private Transform effect3;
    // Start is called before the first frame update
    void Start()
    {
       
        effect = GameObject.Find("Blueeffect").transform;
        effect2 = GameObject.Find("Violeteffect").transform;
        effect3 = GameObject.Find("Redeffect").transform;
        effect.gameObject.SetActive(false);
        effect2.gameObject.SetActive(false);
        effect3.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        ActiveEffect();
    }
    protected void ActiveEffect()
    {
        if (LevelSystem.mylevel.level >= 10)
        {
            effect3.gameObject.SetActive(true);
        }
        if (LevelSystem.mylevel.level >= 15)
        {
            effect3.gameObject.SetActive(false);
            effect.gameObject.SetActive(true);
        }
        if(LevelSystem.mylevel.level >= 25)
        {
           effect.gameObject.SetActive(false);
            effect2.gameObject.SetActive(true);
        }
    }
}
