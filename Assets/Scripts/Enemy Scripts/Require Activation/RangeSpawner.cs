using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeSpawner : EnemyActivate
{
    private float spawnTimer;
    public float spawnInterval;
    public float spawnOffset;
    public GameObject gameObjectToSpawn;
    
    public float range;
    public enum Direction {X, Y}
    public Direction spawnDirection;
    Vector3 spawnPosition;

    private void Start()
    {
        spawnTimer = spawnOffset;
        
    }
    void Update()
    {
        if (active)
        {
            spawnTimer += Time.deltaTime;
            if (spawnTimer >= spawnInterval)
            {
                //randomize position on specified axis
                if (spawnDirection == Direction.X)
                {
                    spawnPosition = new Vector3(transform.position.x + Random.Range(-range, range), transform.position.y, transform.position.z);
                }
                else if (spawnDirection == Direction.Y)
                {
                    spawnPosition = new Vector3(transform.position.x, transform.position.y + Random.Range(-range, range), transform.position.z);
                }

                Instantiate(gameObjectToSpawn, spawnPosition, Quaternion.identity);
                spawnTimer = 0;
            }


        }

    }
}
