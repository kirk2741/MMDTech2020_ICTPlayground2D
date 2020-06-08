using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



//DetectEnemy – Detect whether the enemy is existed or not?
/*
FollowTarget – Move toward the position2D of the given target
ShootWeapon – Shoot any equipped WeaponSystem projectile out
RotateTo – Rotate the assigned oriented axis toward the given position2D
ApplyCollisionDamage – assign a damage to player health directly – due to collision with player
*/

public class EnemyBehaviorA1 : MonoBehaviour
{
    public UnitData unitData;

    // We need rigidBody2D to make a movement
    public Rigidbody2D rigidbody2d;
    // We need Collider2D to allow collision detection
    public Collider2D collider2d;

    // Agent needs to have a memory of what's it target
    public GameObject target;

    // Agent need to have a weapon system here to shoot bullet
    public ShootObjectMultiple weaponProjectileSystem;

   // public List<ShootObjectMultiple> BossWeapon;
    public ShootObjectMultiple BossWeapon1;
    public ShootObjectMultiple BossWeapon2;
    public ShootObjectMultiple BossWeapon3;

    // The direction that will face the target, we use playground’s enums
    public Enums.Directions orientationSide = Enums.Directions.Up;
    public bool EnableFaceToTarget;

    // the option to let agent be active if target is in range
    public float minAggroDistance = 10.0f;
    public bool EnableAggroByDistance;

    public bool EnableEnrage;
    public GameObject newWeapon;
    public float newWeaponSpeed = 10.0f;
    public GameObject part;
    public List<GameObject> body;

    public Healthbar healthbar;
    public bool Boss;

    // Start is called before the first frame update
    void Start()
    {
        if (!rigidbody2d)
        {
            rigidbody2d = GetComponent<Rigidbody2D>();
        }
        if (!collider2d)
        {
            collider2d = GetComponent<Collider2D>();
        }
        HealthSystemAttribute healthSystem = GetComponent<HealthSystemAttribute>();
        if (healthSystem)
        {
            healthbar.SetMaxHealth((int)healthSystem.health);
            healthbar.SetHealth((int)healthSystem.health);
        }
    }

    // Update is called once per frame
    void Update()
    {
        SetupUnitData();
        if (!target) //same as (target == null)
        {
            DetectEnemy();
        }
        else
        {
            if (EnableAggroByDistance)
            {
                if (IsTargetInAggroRange(target.transform))
                {
                    foreach (GameObject i in body)
                    {
                        i.SetActive(true);
                    }
                    FollowTarget();
                    AdjustRotationToTarget();
                    ShootWeapon();
                }else
                {
                    foreach (GameObject i in body)
                    {
                        i.SetActive(false);
                    }
                }
            }
            else
            {
                FollowTarget();
                AdjustRotationToTarget();
                ShootWeapon();
            }
        }
    }

  /*  public GameObject itemdrop;
    public Transform interactionTransform;*/
    public void SetupUnitData()
    {
        // Reference Playground HealthSystemAttribute component

        HealthSystemAttribute healthSystem = GetComponent<HealthSystemAttribute>();
        if (healthSystem)
        {
            healthbar.SetHealth((int)healthSystem.health);
            unitData.health = (int)healthSystem.health;
        }

        if (EnableEnrage)
        {
            if( healthSystem.health < ( healthSystem.maxHealth / 3 ))
            {
                if (Boss)
                {
                    unitData.speed = 5.0f;
                   // foreach (ShootObjectMultiple weapon in BossWeapon)
                   
                    BossWeapon1.shootSpeed = 12.0f;
                    BossWeapon2.shootSpeed = 12.0f;
                    BossWeapon3.shootSpeed = 12.0f;
                    BossWeapon3.prefabToSpawn = newWeapon;
                    part.SetActive(true);
                }
                else
                {
                    unitData.speed = 12.0f;
                    minAggroDistance = 80f;
                    weaponProjectileSystem.shootSpeed = 10.0f;
                    weaponProjectileSystem.largeBullet = true;
                    weaponProjectileSystem.prefabToSpawn = newWeapon;
                    part.SetActive(true);
                }
                
            }
        }
       
    ModifyHealthAttribute modifyHealthAttrb = GetComponent<ModifyHealthAttribute>();
    if (modifyHealthAttrb)
    {
        modifyHealthAttrb.healthChange = (int)-unitData.collisionDamage;
    }
}

    // Agent's action
    public void DetectEnemy()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Agent's Action
    public void FollowTarget()
    {
        // Follow Target
        transform.position = Vector2.MoveTowards(
        transform.position,
        target.transform.position,
        unitData.speed * Time.deltaTime);
    }

    public void AdjustRotationToTarget()
    {
        if (EnableFaceToTarget)
        {//look towards the target, Playground utilities
            Utils.SetAxisTowards(
                orientationSide, 
                transform, 
                target.transform.position - transform.position);
        }
    }


    // Agent's Action
    public void ShootWeapon()
    {
        if (Boss)
        {
            BossWeapon1.ShootObject();
            BossWeapon2.ShootObject();
            BossWeapon3.ShootObject();
        }
        else
        {
            if (weaponProjectileSystem)
            {
                weaponProjectileSystem.ShootObject();
            }
        }

    }

    // Debug Gizmo on selected gameobject
    private void OnDrawGizmosSelected()
    { // Aggro Distance
        if (EnableAggroByDistance)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, minAggroDistance);
        }
    }

    // Helper function to let agent know that given transform is in aggro range or not
    bool IsTargetInAggroRange(Transform theTarget)
    {
        return Vector2.Distance(
        transform.position,
        theTarget.position
        ) <= minAggroDistance;
    }




}
