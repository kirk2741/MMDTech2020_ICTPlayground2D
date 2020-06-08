using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingZone : MonoBehaviour
{
    public GameObject target;
    void OnTriggerEnter2D(Collider2D col)
    {
        target = col.gameObject;
        if (target.CompareTag("Player"))
        {
            HealthSystemAttribute healthSystem = target.GetComponent<HealthSystemAttribute>();
            if(healthSystem.health< healthSystem.maxHealth)
            StartCoroutine("Heal");
        }
          
    }

    void OnTriggerExit2D(Collider2D col)
    {
        target = col.gameObject;
        if (target.CompareTag("Player"))
            StopCoroutine("Heal");
    }

    IEnumerator Heal()
    {
        HealthSystemAttribute healthSystem = target.GetComponent<HealthSystemAttribute>();
            for (float currentHealth = healthSystem.health; currentHealth < healthSystem.maxHealth; currentHealth += 1)
        {
            healthSystem.ModifyHealth(1);
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}
