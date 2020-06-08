using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Changeweapon : MonoBehaviour
{
    public ShootObjectMultiple oldWeapon;
    public GameObject newWeapon;
    public ObjectShooter oldShooter;
    public bool destroyWhenActivated;
    private GameObject target;
        
    private void OnCollisionEnter2D(Collision2D collisionData)
    {
        OnTriggerEnter2D(collisionData.collider);
    }
    private void OnTriggerEnter2D(Collider2D colliderData)
    {
        target = colliderData.gameObject;
        if (target.CompareTag("Player"))
        {
            oldShooter.prefabToSpawn = newWeapon;
            oldWeapon.prefabToSpawn = newWeapon;
            oldShooter.shootSpeed = 13.0f;
            oldWeapon.shootSpeed = 13.0f;
            if (destroyWhenActivated)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
