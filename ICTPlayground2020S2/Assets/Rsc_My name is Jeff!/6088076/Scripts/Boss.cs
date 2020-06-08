using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    
    public int health = 500;
    public GameObject deathEffect;
    public UIScript ui;
    public GameObject Button;
    public GameObject target;

    void start()
    {
        ui = GameObject.FindObjectOfType<UIScript>();
        Button.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
        target = GameObject.FindGameObjectWithTag("Boss");
        if (!target)
        {
            Die();
        }
        else
        {
            HealthSystemAttribute healthSystem = target.GetComponent<HealthSystemAttribute>();
            if (healthSystem)
            {
                health = (int)healthSystem.health;
            }
            if (health <= 0)
            {
                Die();
            }
        }
    }
    public void Die()
    {
        ui.GameWon(0);
        Button.SetActive(true);
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(target);
    }
    public void CommandDie()
    {
        target = GameObject.FindGameObjectWithTag("Boss");
        HealthSystemAttribute healthSystem = target.GetComponent<HealthSystemAttribute>();
        ui.GameWon(0);
        Button.SetActive(true);
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        healthSystem.ModifyHealth(-500);
        Destroy(target);
    }
}
