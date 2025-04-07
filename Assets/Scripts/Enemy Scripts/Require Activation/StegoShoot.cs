using NodeCanvas.Tasks.Actions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class StegoShoot : EnemyActivate
{

    //keeps track of when it shoots
    private float shootTimer; //how much has passed since activation
    [SerializeField] private float shootTime; //how many seconds until it shoots spines

    //keeps track of the three spines it'll shoot
    MoveDirection[] childrenScripts;

    void Start()
    {
        childrenScripts = GetComponentsInChildren<MoveDirection>(); //get a reference to all spines (its three rn)
    }

    void Update()
    {
        if (active)
        {
            shootTimer += Time.deltaTime;

            if (shootTimer >= shootTime)
            {
                foreach(MoveDirection script in childrenScripts)
                {
                    script.enabled = true; //enables the moevement script on all spines, shooting them
                }
                active = false; //only shoots once, so it deactivates the gameobject
            }
        }
    }
}
