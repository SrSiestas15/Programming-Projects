using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFall : MonoBehaviour
{
    private float health;
    public float speed;
    private bool falling = false;
    private Rigidbody2D enemyRB;

    void Start()
    {
        //health = GetComponent<PlayerDamageAndParry>().health;
        enemyRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (PlayerMoveAndShoot.playerTransform.position.x < transform.position.x + 1 && PlayerMoveAndShoot.playerTransform.position.x > transform.position.x - 1)
        {
            //Debug.Log("under coral");
            falling = true;
        }
    }
    private void FixedUpdate()
    {
        if (falling)
        {
            Debug.Log(falling);
            enemyRB.velocity += Vector2.down * speed;
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject); //destroys the falling thing when it goes off-screen
    }
}
