using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    void OnTriggerEnter2D(Collider2D col)
    {
        target = col.gameObject;
        if (target.CompareTag("Player"))
        {
            HealthSystemAttribute healthSystem = target.GetComponent<HealthSystemAttribute>();
           // ModifyHealthAttribute modifyHealthAttrub = GetComponent<ModifyHealthAttribute>();
            if (healthSystem.health < 100)
            {

            }
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
