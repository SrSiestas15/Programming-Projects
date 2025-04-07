using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropAfter : MonoBehaviour
{
    private MoveDirection moveScript;
    private TakeDamage healthScript;

    private Collider2D currentCollider;
    private SpriteRenderer childSprite;

    void Start()
    {
        //used to keep track of health and falling
        moveScript = GetComponentInParent<MoveDirection>();
        healthScript = GetComponent<TakeDamage>();

        //used to turn off shootable
        currentCollider = GetComponent<Collider2D>();
        childSprite = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        if(healthScript.health <= 0) //after health reaches 0
        {
            //make shootable "dissapear"
            currentCollider.enabled = false;
            childSprite.enabled = false;

            //make gameobject fall
            moveScript.runDirection.y -= 6 * Time.deltaTime;
            
        }
    }
}
