using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateGravity : EnemyActivate
{
    [SerializeField] float newGravity;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (active)
        {
            rb.gravityScale = newGravity;
        }
    }
}
