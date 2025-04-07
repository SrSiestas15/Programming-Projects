using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyfishAttack : EnemyActivate
{
    public GameObject attackZone;

    public bool isAttacking;
    private float jellyfishTimer;
    public float attackTime; //how long the attack should last

    float originalHealth;

    TakeDamage jellyfishTakeDamage;

    private void Start()
    {
        jellyfishTakeDamage = GetComponent<TakeDamage>();
        originalHealth = jellyfishTakeDamage.health;
    }

    void Update()
    {
        if (active)
        {   
            if(jellyfishTakeDamage.health <= 0)
            {
                isAttacking = true;
                jellyfishTimer += Time.deltaTime;
                if (jellyfishTimer >= attackTime)
                {
                    isAttacking = false;
                    jellyfishTimer = 0;
                    jellyfishTakeDamage.health = originalHealth;
                }
            }

            if (isAttacking)
            {
                attackZone.SetActive(true);
            } else attackZone.SetActive(false);

        }
    }
}
