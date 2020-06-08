using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public int health;
    public Text healhNum;


    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        fill.color = gradient.Evaluate(1f);
        healhNum.text = health.ToString();

    }
    public void SetHealth(int health)
    {
        slider.value = health;
        healhNum.text = health.ToString();
        fill.color = gradient.Evaluate(slider.normalizedValue);
       
    }

   


}
