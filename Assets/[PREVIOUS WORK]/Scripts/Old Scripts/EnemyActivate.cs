using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActivate : MonoBehaviour
{
    [Header("Activation Variables")]
    public bool active;
    public bool alwaysActive; //for special instances like objects being instantiated (active needs to be turned on by default as well for this to work)
    
    public bool stayOnScreen; //for enemies that stay on screen for period of time
    public bool ignoreLeaveTrigger; //for instance like the beam where they leave another way
    public float stayOnDistance = 0.5f; //distance from screen right that stay on enemies sit
    private float stayOnTimer = 0f;
    public enum TriggerZone {far, near}
    public TriggerZone zone; //determines the distance/trigger zone at which an enemy will activate
    

    void Start()
    {
        if (alwaysActive) //start active if doesn't require activation
        {
            active = true;
        } else
        {
            active = false;

        }
    }

    void Update()
    {
        if (alwaysActive) //keep active is doesn't require activation
        {
            active = true;
        }
        
        //none of the code in here is running for some reason?!?!


    }

    private void OnTriggerEnter2D(Collider2D collision) //activates objects on trigger enter
    {
        if (!alwaysActive)
        {
            
            if (zone == TriggerZone.far && collision.tag == "Far") //if enters far collider
            {
                active = true;
            }

            if (zone == TriggerZone.near && collision.tag == "Near") //if enters near collider
            {
                active = true;
            }

            if (stayOnScreen && collision.tag == "Clear Stay-On" && !ignoreLeaveTrigger) //if a stay on enemy collides with the clear stay on trigger
            {
                //no longer stay on screen
                transform.SetParent(null);
                stayOnScreen = false;
                stayOnTimer = 0f;
            }

        }
    }

    private void OnTriggerStay2D(Collider2D collision) //keeps objects activate when in trigger
    {
        if (!alwaysActive)
        {
            if (zone == TriggerZone.far && collision.tag == "Far") //if stays in far collider
            {
                active = true;
            }

            if (zone == TriggerZone.near && collision.tag == "Near") //if stays in near collider
            {
                active = true;

                if (stayOnScreen) //if a stay on screen enemy, keep it on screen until reaches exit collider
                {
                    stayOnTimer += Time.deltaTime; //start brief timer (timer determines distance from right of screen)
                    if (stayOnTimer >= stayOnDistance)
                    {
                        transform.SetParent(GameObject.Find("Main Camera").transform); //assign gameObject as a child of the camera
                    }
                }
            }

        }
    }

    private void OnTriggerExit2D(Collider2D collision) //deactivates objects after trigger exit
    {
        
        if (!alwaysActive)
        {
            if (zone == TriggerZone.far && collision.tag == "Far") //if exits far ollider
            {
                active = false;
            }

            if (zone == TriggerZone.near && collision.tag == "Near") //if exits near collider
            {
                active = false;
            }

        }
    }

}
