using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDirection : EnemyActivate
{
    [Space(5)]
    [Header("Move Direction Variables")]
    Rigidbody2D rb;
    public float speed;
    public Vector2 runDirection;
    public bool homing;
    [SerializeField] bool runLeft;
    [Space(5)]

    public bool rotateOnTrigger;
    public float rotationAngle; //rotates the run direction COUNTER-CLOCKWISE


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        runDirection = runDirection.normalized;

        if (homing) //if homing, move in the direction of the player
        {
            runDirection = (PlayerMoveAndShoot.playerTransform.position - transform.position).normalized;

        }

    }

    private void Update()
    {
        if (runLeft)
        {
            runDirection = (-transform.right).normalized;
        }

        if (active)
        {
            
            rb.velocity = runDirection * speed;
        }


    }

    private void OnTriggerEnter2D(Collider2D whoCollided)
    {
        if (whoCollided.gameObject.layer == 15)
        {
            Destroy(gameObject);
        }

        if (whoCollided.tag == "Special Action" && rotateOnTrigger) //if it collides with a trigger tagged special action, rotate
        {
            rb.MoveRotation(-rotationAngle);
            Vector2 oldDirection = runDirection;
            runDirection = (oldDirection + new Vector2(-1 * Mathf.Cos(Mathf.Deg2Rad * rotationAngle), Mathf.Sin(Mathf.Deg2Rad * rotationAngle))).normalized;
        }
    }

}

