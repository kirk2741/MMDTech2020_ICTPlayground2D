using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int DamageDone = 10;
    private void OnTriggerEnter(Collider other)
    {
        ShowDamage.Getdamage = true;
        ShowDamage.DamageGet = DamageDone;
        Health.currentHealth -= DamageDone;
    }
    
}
