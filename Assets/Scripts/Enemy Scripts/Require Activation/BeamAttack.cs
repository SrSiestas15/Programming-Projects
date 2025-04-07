using NodeCanvas.Tasks.Actions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class BeamAttack : EnemyActivate
{
    //after activation, the beam attack:
    //"aims" for a certain window of time (action depends on beamType)
    //then "fires" for a certain period of time (activating the collider)


    private float beamTimer;

    private enum action {Aiming, Waiting, Attacking, Leaving}
    private action currentAction = action.Aiming;

    private enum beamType {Static, Rotate, FollowHor, FollowVer}
    //type of beam describes what it does during "aiming" period
    //static: does not move while aiming
    //rotate: rotates to look towards player
    //followHor: moves side to side to match player x-pos
    //followVer: moves up and down to match player y-pos
    [Space(5)]
    [Header("Beam Variables")]
    [SerializeField] private beamType chosenType; //choose the type of beam in the inspector
    [SerializeField] private float aimSpeed; //the speed at which the beam tries to aim towards the player

    [SerializeField] private float aimTime; //how long the aiming lasts for
    [SerializeField] private float waitTime; //how long the wait before shooting lasts for (should be short)
    [SerializeField] private float attackTime; //how long the beam attack lasts for
    [SerializeField] private float repeats; //how many times the beam attacks before leaving

    private float timesRepeated;

    private GameObject beamAttack;

    private Vector3 positionBeforeLeaving;


    //for rotate
    float currentAngle;

    private void Start()
    {
        beamAttack = GameObject.Find("Beam");
        beamAttack.SetActive(false);
        
    }

    private void Update()
    {
        if (active)
        {
            beamTimer += Time.deltaTime;

            if (currentAction == action.Aiming) //aiming logic for each type of beam
            {
                if (beamTimer >= aimTime)
                {
                    currentAction = action.Waiting; //switches to next action when aimTime is over
                    beamTimer = 0;
                }

                int direction; //used to calculate what direction to aim towards

                if (chosenType == beamType.Static)
                {
                    //nothing! ^_^
                }
                else if (chosenType == beamType.Rotate)
                {
                    //endPoint = transform.position + transform.right;
                    Vector3 tempVector = PlayerMoveAndShoot.playerTransform.position - transform.position;
                    float targetAngle = Mathf.Atan2(tempVector.y, tempVector.x) * Mathf.Rad2Deg;
                    //Debug.DrawLine(transform.position, endPoint, Color.blue);

                    currentAngle = transform.eulerAngles.z + 180;

                    //if (MathF.Sign(targetAngle) == -1)
                    //{
                    //    targetAngle = targetAngle * -2;
                    //    //transform.Rotate(0, 0, -aimSpeed * Time.deltaTime);
                    //}

                    if (currentAngle < targetAngle)
                    {
                        transform.Rotate(0, 0, aimSpeed * Time.deltaTime);
                    }
                    if (currentAngle > targetAngle)
                    {
                        transform.Rotate(0, 0, -aimSpeed * Time.deltaTime);
                    }

                    Debug.Log("target angle: " + targetAngle);
                    Debug.Log("current angle: " + currentAngle);
                    Debug.Log(transform.eulerAngles.z + 180);
                }
                else if (chosenType == beamType.FollowHor)
                {
                    if (PlayerMoveAndShoot.playerTransform.position.x < transform.position.x) direction = -1; //checks if the player is to the left
                    else direction = 1; //or right

                    transform.position += Vector3.right * aimSpeed * direction * Time.deltaTime; //moves towards left or right at aimSpeed
                }
                else if (chosenType == beamType.FollowVer)
                {
                    if (PlayerMoveAndShoot.playerTransform.position.y < transform.position.y) direction = -1; //checks if the player is below
                    else direction = 1; //or above

                    transform.position += Vector3.up * aimSpeed * direction * Time.deltaTime; //moves up or down at aimSpeed
                }
            }
            else if (currentAction == action.Waiting) //a little pause before shooting
            {
                if (beamTimer >= waitTime)
                {
                    currentAction = action.Attacking;
                    beamTimer = 0;
                }
            }
            else if (currentAction == action.Attacking) //shooting
            {
                beamAttack.SetActive(true); //turn on beam attack and collider

                if (beamTimer >= attackTime)
                {
                    timesRepeated++;

                    if(timesRepeated >= repeats)
                    {
                        currentAction = action.Leaving;
                        positionBeforeLeaving = transform.position;
                    }
                    else
                    {
                        currentAction = action.Aiming;
                        beamAttack.SetActive(false);
                    }
                    
                    beamTimer = 0;
                }
            }
        }

        if (currentAction == action.Leaving)
        {
            ///imagine it goes offscreen (checking what type of beam it is to check how it should leave)
            ///to go off-screen we'd have to either look at the camera speed to beat it or have it as a child of the camera
            ///then it destroys itself offscreen yay
            beamAttack.SetActive(false);

            transform.position += transform.right * 5 * Time.deltaTime;
            Vector3 goal = positionBeforeLeaving + transform.right * 20;
            if ((goal - transform.position).magnitude < 0.2)
            {
                Destroy(gameObject);

            }
        }
    }
}
