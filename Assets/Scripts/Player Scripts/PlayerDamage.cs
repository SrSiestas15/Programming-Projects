using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDamage : MonoBehaviour
{
    /* 
     * Script used for:
     * Player lives
     * Player taking damage
     
     */

    public static int maxLives = 3;
    public static int livesRemaining = maxLives;


    [SerializeField] GameObject explosionPrefab;

    public float invincibleTime; 
    bool isInvincible = false;

    private ShipSpawner shipSpawnerScript; //to respawn ship after death (in camera gO)



    void Start()
    {
        shipSpawnerScript = GetComponentInParent<ShipSpawner>();
    }


    void Update()
    {
        if (livesRemaining <= 0)
        {
            Transform respawnTransform = GetComponentInParent<Transform>();
            transform.position = respawnTransform.position;
            livesRemaining = maxLives;
            ScoreTracker.LevelDeaths++;
            Debug.Log("respawn: " + respawnTransform);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy" || collision.gameObject.layer == 8 || collision.gameObject.layer == 9 || collision.gameObject.layer == 15)
        {
            TakeDamage(collision);
        }
    }

    //everything below here is really wonky !!!!!
    //we need to figure out why the knocback is being clamped
    //and a way to show i-frames
    void TakeDamage(Collider2D collision)
    {
        if (!isInvincible)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            if (collision.tag != "Enemy" && collision.gameObject.layer != 8)
            {
                Destroy(collision.gameObject);
            }

            Destroy(gameObject);
            shipSpawnerScript.StartCoroutine("SpawnShip");
            
            livesRemaining--;
        }
    }
}
