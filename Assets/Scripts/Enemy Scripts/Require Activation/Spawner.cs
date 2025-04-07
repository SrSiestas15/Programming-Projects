using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : EnemyActivate
{
    [Space(5)]
    [Header("Spawner Variables")]
    [SerializeField] private float spawnTimer;
    public float spawnInterval;
    public float spawnOffset;
    public GameObject gameObjectToSpawn;

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
                Instantiate(gameObjectToSpawn, transform.position, Quaternion.identity);
                spawnTimer = 0;
            }


        }

    }
}
