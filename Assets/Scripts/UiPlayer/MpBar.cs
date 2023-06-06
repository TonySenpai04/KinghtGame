using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MpBar : MonoBehaviour
{
    public Slider mpslider;
    public void SetMaxMp(float mp)
    {
        mpslider.maxValue = mp;
    }
    public void SetMp(float mp)
    {
        mpslider.value = mp;
    }
    // Start is called before the first frame update
   
}
