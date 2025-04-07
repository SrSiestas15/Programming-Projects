using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeekMovement : EnemyActivate
{
    private Collider2D[] leek;
    private int currentLeek = 0;

    private enum movementStages { up, left, down, wait}
    private movementStages currentStage = movementStages.up;

    [SerializeField] float moveUp;
    [SerializeField] float moveLeft;
    [SerializeField] float waitTime;
    [SerializeField] float speed;

    private float endUp;
    private float endLeft;
    private float endDown;
    private float waitTimer;

    public static Transform leekTransform1;
    public static Transform leekTransform2;

    void Start()
    {
        leek = GetComponentsInChildren<Collider2D>();

        endUp = leek[currentLeek].gameObject.transform.position.y + moveUp;
        endLeft = leek[currentLeek].transform.position.x - moveLeft;
        endDown = leek[currentLeek].gameObject.transform.position.y;

        leekTransform1 = leek[0].transform;
        leekTransform2 = leek[1].transform;
    }

    void Update()
    {
        //Debug.Log(currentStage);
        if (active)
        {
            leekTransform1 = leek[0].transform;
            leekTransform2 = leek[1].transform;

            if(currentStage == movementStages.up)
            {
                leek[currentLeek].gameObject.transform.position += Vector3.up * speed * Time.deltaTime;
            }
            else if (currentStage == movementStages.left)
            {
                leek[currentLeek].gameObject.transform.position -= Vector3.right * speed * Time.deltaTime;
            }
            else if (currentStage == movementStages.down)
            {
                leek[currentLeek].gameObject.transform.position -= Vector3.up * speed * Time.deltaTime;
            }
            else if (currentStage == movementStages.wait)
            {
                waitTimer++;
            }
        }

        if(leek[currentLeek].gameObject.transform.position.y > endUp)
        {
            currentStage = movementStages.left;
        }
        if(leek[currentLeek].gameObject.transform.position.x < endLeft)
        {
            currentStage = movementStages.down;
        }
        if (leek[currentLeek].gameObject.transform.position.y < endDown)
        {
            currentStage = movementStages.wait;
        }
        if (waitTimer >= waitTime)
        {
            if (currentLeek == 0)
            {
                currentLeek = 1;
            } 
            else if (currentLeek == 1)
            {
                currentLeek = 0;
            }
            waitTimer = 0;
            endLeft = leek[currentLeek].transform.position.x - moveLeft;
            currentStage = movementStages.up;
        }
    }
}
