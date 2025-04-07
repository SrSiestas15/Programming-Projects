using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using UnityEngine;

public class BossFish : MonoBehaviour
{
    public bool isStunned;
    public bool dashEels;
    public Transform eelspawn1;
    public Transform eelspawn2;
    public Transform eelspawn3;
    public Transform eelspawn4;
    public GameObject fishPrefab;
    public GameObject bubblePrefab;
    public GameObject eelPrefab;
    public string shotDirection;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void SpawnFish(float horizontalOffset, float verticalOffset)
    {
        Vector3 newTransform = new Vector3(horizontalOffset, verticalOffset, 0);
        fishPrefab.GetComponent<MoveDirection>().speed = 12;
        Instantiate(fishPrefab, transform.position + newTransform, Quaternion.identity);
    }

    public void SpawnBubble(bool inverse)
    {
        bubblePrefab.GetComponent<WaveMovement>().inverse = inverse;
        Instantiate(bubblePrefab, transform.position, Quaternion.identity, gameObject.transform);
    }

    public void SpawnEels(int attackLevel)
    {
        Instantiate(eelPrefab, eelspawn1);
        Instantiate(eelPrefab, eelspawn2);
        if(attackLevel > 2)
        {
            Instantiate(eelPrefab, eelspawn3);
            Instantiate(eelPrefab, eelspawn4);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Special Action")
        {
            if(collision.GetComponent<JellyfishAttack>() != null)
            {
                JellyfishAttack jellyfishCollision = collision.GetComponent<JellyfishAttack>();
                if (jellyfishCollision.isAttacking)
                {
                    isStunned = true;
                }
            }
        }

        if(collision.gameObject.tag == "Player Projectile")
        {
            Vector3 directionToBullet = collision.transform.position - transform.position;
            if (directionToBullet.y < .5)
            {
                shotDirection = "below";
            }
            else if (directionToBullet.y > .5)
            {
                shotDirection = "above";

            }
            else shotDirection = "center";
        }
    }
}
