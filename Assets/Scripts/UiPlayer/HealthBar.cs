using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthbarSlider;
    
    public void SetMaxHp(float health)
    {
        healthbarSlider.maxValue=health;
        
    }
    public void SetHp(float health)
    {
        healthbarSlider.value = health;
        
    }
  



}
