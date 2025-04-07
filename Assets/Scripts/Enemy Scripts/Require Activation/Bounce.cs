using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : EnemyActivate
{
    float gravity;
    public float apexHeight;
    public float apexTime;
    private float initialBounceVelocity;

    public Vector2 bounceDirection;

    private Rigidbody2D gameobjectRB;

    public bool isArrow;

    // Start is called before the first frame update
    void Start()
    {
        gameobjectRB = GetComponent<Rigidbody2D>();
        gravity = -3 * apexHeight / Mathf.Pow(apexTime, 2);
        initialBounceVelocity = 2 * apexHeight / apexTime;

        if (isArrow)
        {
            Vector3 vectorToShip = PlayerMoveAndShoot.playerTransform.position - transform.position;
            bounceDirection = vectorToShip;
            bounceDirection.y += 4;
            BounceAction();

        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isArrow || active)
        {
            gameobjectRB.velocity += Vector2.up * Time.deltaTime * gravity;
            gameobjectRB.velocity = Vector2.ClampMagnitude(gameobjectRB.velocity, 10);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (active)
        {
            if (collision.tag == "Environment")
            {
                BounceAction();
            }
            else if (collision.gameObject.tag == "Enemy Projectile")
            {
                Destroy(gameObject);
            }

        }
    }

    private void BounceAction()
    {
        gameobjectRB.velocity += bounceDirection * initialBounceVelocity;
        
    }
}
