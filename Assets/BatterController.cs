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

    public bool readyUp;

    void Update()
    {
        if(baseballGO != null) //if there's currently a baseball that the batter is paying attention to
        {
            if((baseballGO.transform.position - transform.position).magnitude < .2f)
            {
                pitchedTo = true; //the pitcher's throw has been caught by batter
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<BaseballController>() != null) //get a reference to the baseball that the batter collided with
        {
            baseballGO = collision.gameObject;
        }
    }
}
