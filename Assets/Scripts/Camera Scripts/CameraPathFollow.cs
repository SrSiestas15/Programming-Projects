using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CameraPathFollow : MonoBehaviour
{
    Camera mainCamera;

    public GameObject cameraTransitionParent;
    private Transform[] waypoints; 
    private int nextWaypoint = 1;
    private WaypointScript nextWaypointScript;

    public bool setConsistentSpeed;
    public float consistentCameraSpeed;

    public int waypointToStartAt;

    private Vector3 toNextWaypoint;

    private Vector3 currentVelocity;
    private float intendedSpeed;

    private float acceleration;
    private float deceleration;
    public float timeToReachMaxSpeed;
    public float timeToDecelerate;


    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GetComponent<Camera>();

        waypoints = cameraTransitionParent.GetComponentsInChildren<Transform>();

        //check what waypoint to start at (waypoint to start at would only be changed for testing purposes)
        if (waypointToStartAt != 0)
        {
            nextWaypoint = waypointToStartAt;
            transform.position = waypoints[waypointToStartAt].position;
        }
        
        nextWaypointScript = waypoints[nextWaypoint].gameObject.GetComponent<WaypointScript>(); //fetch waypoint script of current waypoint
        
        if (nextWaypointScript.locked)
        {
            //waypoint locked
            StopCamera();
        }
        else
        {
            //waypoint unlocked
            intendedSpeed = nextWaypointScript.speed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (setConsistentSpeed)
        {
            SetConsistentSpeed(consistentCameraSpeed);
        }

        if (nextWaypoint < waypoints.Length) //if current waypoint is within the index of the list
        {

            //get vector to nextwaypoint
            toNextWaypoint = waypoints[nextWaypoint].position - transform.position;


            //accelerate
            if (intendedSpeed > currentVelocity.magnitude)
            {
                acceleration = intendedSpeed / timeToReachMaxSpeed;
                currentVelocity += acceleration * Time.deltaTime * toNextWaypoint.normalized;
                currentVelocity = Vector3.ClampMagnitude(currentVelocity, nextWaypointScript.speed);
            }

            //decelerate
            if (intendedSpeed < currentVelocity.magnitude && currentVelocity.magnitude != 0)
            {
                if (intendedSpeed == 0)
                {
                    //if decelerating to 0, deceleration is 1
                    deceleration = 1.5f;
                } else
                {
                    //if decelerating to any other speed, calculate the proper deceleration
                    deceleration = intendedSpeed / timeToDecelerate;
                }
                currentVelocity -= Vector3.ClampMagnitude(currentVelocity.normalized * deceleration * Time.deltaTime, currentVelocity.magnitude);
            }

            if (nextWaypointScript.locked)
            {
                //waypoint locked
                StopCamera();
            }
            else
            {
                //waypoint unlocked
                intendedSpeed = nextWaypointScript.speed;
            }

            //apply changes to camera transform
            mainCamera.transform.position += currentVelocity * Time.deltaTime;
            
            if (toNextWaypoint.magnitude < 0.5)
            {
                //switch to next waypoint
                if ((nextWaypoint + 1) != waypoints.Length)
                {
                    //move to next waypoint in list
                    nextWaypoint++;
                    nextWaypointScript = waypoints[nextWaypoint].gameObject.GetComponent<WaypointScript>(); //fetch waypoint script of current waypoint
                } else
                {
                    //at the end of the waypoint list
                    StopCamera();
                }
            } 
        }
    }
    
    //WE ARE PROBABLY CUTTING WAYPOINT DETOURS
    public void WaypointDetour(Transform detourWaypoint)
    {
        waypoints[nextWaypoint] = detourWaypoint;
    }

    public void SetConsistentSpeed(float speed)
    {
        //sets all waypoints to have the same speed value
        for (int i = 1; i < waypoints.Length; i++)
        {
            waypoints[i].gameObject.GetComponent<WaypointScript>().speed = speed;
        }
    }

    void StopCamera()
    {
        //decelerates the camera to a stop
        intendedSpeed = 0;
    }

}
