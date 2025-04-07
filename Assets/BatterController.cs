using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEditor;

public class BatterController : MonoBehaviour
{
    public bool pitchedTo;
    public GameObject baseballGO;

    public enum States
    {
        waiting,
        ready,
        busy,
    }
    public static States currentState;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(baseballGO != null)
        {
            if((baseballGO.transform.position - transform.position).magnitude < .2f)
            {
                pitchedTo = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<BaseballController>() != null)
        {
            baseballGO = collision.gameObject;
        }
    }
}
