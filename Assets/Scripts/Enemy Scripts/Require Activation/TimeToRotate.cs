using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class TimeToRotate : EnemyActivate
{
    private MoveDirection[] childrenScripts; //to house child gameObjects with the moveDirection() script
    
    private float rotateTimer; //begins once the gameObject is "active"
    [SerializeField] private float timeToRotate; //how long until the rotation occurs
    
    [SerializeField] private float newAngle; //what the children's new angle should be
    [SerializeField] private float newSpeed; //what the children's new speed should be
    
    private bool rotated; //whether or not the rotation has happened yet

    void Start()
    {
        childrenScripts = GetComponentsInChildren<MoveDirection>(); //get ref to all children
    }

    void Update()
    {
        if (active)
        {
            rotateTimer += Time.deltaTime;
            if (rotateTimer >= timeToRotate && !rotated)
            {
                for (int i = 0; i < childrenScripts.Length; i++)
                {
                    childrenScripts[i].gameObject.transform.eulerAngles = new Vector3(0, 0, newAngle); //sets the new angle for each child
                    childrenScripts[i].speed = newSpeed;
                    newAngle *= -1; //this is here so the angle is reflected depending on the children (for the popsicles it turns one [degrees] then the other -[degrees]) tweak as you see fit
                }
                rotated = true;
            }
        }
    }
}
