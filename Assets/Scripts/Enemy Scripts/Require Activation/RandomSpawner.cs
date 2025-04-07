using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : EnemyActivate
{
    [Space(5)]
    [Header("Spawner Variables")]
    [SerializeField] private float spawnTimer;
    public float spawnInterval;
    public float spawnOffset;

    private GameObject gameObjectToSpawn;
    [SerializeField] GameObject[] gameObjectsToSpawn; //place prefabs to choose from in the inspector
    private Transform[] spawnPoints; //used to find the correct spawnpoint in hirearchy
    private Transform chosenSpawn; //stores the correct spawn point's transform

    private void Start()
    {
        spawnTimer = spawnOffset;
        spawnPoints = GetComponentsInChildren<Transform>();
        foreach (Transform t in spawnPoints)
        {
            if(t.gameObject.name == "shootFrom") //the spawn point's transform has to be in a game object called shootFrom!!!
            {
                chosenSpawn = t;
            }
        }
    }
    void Update()
    {
        if (active)
        {
            spawnTimer += Time.deltaTime;
            if (spawnTimer >= spawnInterval)
            {
                int randAttack = Random.Range(0, gameObjectsToSpawn.Length);
                gameObjectToSpawn = gameObjectsToSpawn[randAttack];
                if(chosenSpawn != null)
                {
                    Instantiate(gameObjectToSpawn, chosenSpawn.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(gameObjectToSpawn, transform.position, Quaternion.identity);
                }
                spawnTimer = 0;
            }


        }

    }
}
