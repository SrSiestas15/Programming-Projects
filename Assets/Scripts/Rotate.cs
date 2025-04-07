using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Rotate : EnemyActivate
{
    private enum typeOfRotate { rigidBody, sprite}
    [SerializeField] typeOfRotate type;

    public float speed;
    private Rigidbody2D rb;

    private float newDegree = 0;

    void Start()
    {
        if(type == typeOfRotate.rigidBody)
        {
            rb = gameObject.GetComponent<Rigidbody2D>(); //get rigidbody
            rb.AddTorque(speed, ForceMode2D.Impulse); //apply torque
            rb.angularDrag = 0f; //set to no drag
        }
    }

    void Update()
    {
        if (active)
        {
            if(type == typeOfRotate.sprite)
            {
                newDegree += Time.deltaTime * speed;
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, newDegree));
            }
        }
    }
}
