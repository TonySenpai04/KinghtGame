using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class healthbarenemy : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider HpSlider;
    [SerializeField] protected Gradient gradient;
    [SerializeField] protected Image fill;
    public void setmaxh(float health)
    {
      HpSlider.maxValue = health;
        fill.color = gradient.Evaluate(1f);
    }
    public void sethp(float health)
    {
        HpSlider.value = health;
        fill.color = gradient.Evaluate(HpSlider.normalizedValue);
    }

}
