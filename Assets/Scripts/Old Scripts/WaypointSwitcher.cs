using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointSwitcher : MonoBehaviour
{
    public Transform associatedWaypoint;
    private TakeDamage damageScript;
    public CameraPathFollow cameraScript;

    void Start()
    {
        damageScript = gameObject.GetComponent<TakeDamage>();
    }

    // Update is called once per frame
    void Update()
    {
        if (damageScript.health <= 0)
        {
            //switch waypoint
            cameraScript.WaypointDetour(associatedWaypoint);
            Destroy(gameObject);

        }
    }
}
