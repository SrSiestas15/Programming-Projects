using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEel : EnemyActivate
{
    public bool isElectrified;
    public float electrifiedTimer;
    public float electrifiedTime;

    float eelHealth;
    float eelMaxHealth;

    TakeDamage eelTakeDamage;
    SpriteRenderer eelRenderer;
    public Sprite eelSpriteNormal;
    public Sprite eelSpriteElectric;

    void Start()
    {
        eelTakeDamage = GetComponent<TakeDamage>();
        eelRenderer = GetComponentInChildren<SpriteRenderer>();


        eelMaxHealth = eelTakeDamage.health;
        //Debug.Log("eelmaxhealth"+eelMaxHealth);
    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log("eelhealth"+eelHealth);
        if (eelTakeDamage.health <= 0)
        {
            isElectrified = true;
        }

        if (isElectrified)
        {
            eelRenderer.sprite = eelSpriteElectric;
            electrifiedTimer += Time.deltaTime;
            if (electrifiedTimer >= electrifiedTime)
            {
                isElectrified = false;
                electrifiedTimer = 0;
                eelTakeDamage.health = eelMaxHealth;
            }
        }
        else eelRenderer.sprite = eelSpriteNormal;
    }

    void BecomeElectrified()
    {

    }



}
