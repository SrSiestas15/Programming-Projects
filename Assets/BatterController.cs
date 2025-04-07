using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BatterController : MonoBehaviour
{
    public bool pitchedTo;
    public GameObject baseballGO;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<BaseballController>() != null)
        {
            baseballGO = collision.gameObject;
            pitchedTo = true;
        }
    }
}
