using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CircleHealthbar : MonoBehaviour
{
    public Gradient gradient;
    public Image fill;
    public Text healhNum;
    public float maxhealth;
    public float health;


    public void SetMaxHealth(float maxvalue)
    {
        maxhealth = maxvalue;
        health = maxvalue;
        float amount = maxvalue / maxhealth;
        fill.fillAmount = amount;
        fill.color = gradient.Evaluate(1f);
        healhNum.text = health.ToString();
    }
    public void SetHealth(float current)
    {
        if(current <= 0)
        {
            current = 0;
        }
        if (current >= maxhealth)
        {
            current = maxhealth;
        }

        health = current;
        float amount = current / maxhealth;
        fill.fillAmount = amount;
        int hp = (int)current;
        healhNum.text = hp.ToString();
        fill.color = gradient.Evaluate(fill.fillAmount);

    }

}
