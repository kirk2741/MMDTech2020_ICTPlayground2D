using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CircleHealthbar Circlehealthbar;
    public UIScript ui;
    // Start is called before the first frame update
    void Start()
    {
        HealthSystemAttribute healthSystem = GetComponent<HealthSystemAttribute>();
        Circlehealthbar.SetMaxHealth((int)healthSystem.maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        HealthSystemAttribute healthSystem = GetComponent<HealthSystemAttribute>();
        if (healthSystem)
        {
            Circlehealthbar.SetHealth(healthSystem.health);
        }




    }

}
