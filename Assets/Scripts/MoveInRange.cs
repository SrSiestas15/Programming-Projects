using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInRange : MonoBehaviour
{
    enum directions { vertical, horizontal }
    [SerializeField] private directions direction;
    [SerializeField] float range;
    [SerializeField] float speed;

    private float finalPos1;
    private float finalPos2;
    private float currentGoal = 1;

    // Start is called before the first frame update
    void Start()
    {
        if (direction == directions.vertical)
        {
            finalPos1 = transform.position.y + range;
            finalPos2 = transform.position.y - range;
        }
        else if (direction == directions.horizontal)
        {
            finalPos1 = transform.position.x + range;
            finalPos2 = transform.position.x - range;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (direction == directions.vertical)
        {
            if (currentGoal == 1)
            {
                transform.position += Vector3.up * speed * Time.deltaTime;
            }
            else if (currentGoal == 2)
            {
                transform.position -= Vector3.up * speed * Time.deltaTime;
            }

            if (transform.position.y > finalPos1)
            {
                currentGoal = 2;
            }
            if (transform.position.y < finalPos2)
            {
                currentGoal = 1;
            }

        }
        else if (direction == directions.horizontal)
        {
            if (currentGoal == 1)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
            else if (currentGoal == 2)
            {
                transform.position -= Vector3.right * speed * Time.deltaTime;
            }

            if (transform.position.x > finalPos1)
            {
                currentGoal = 2;
            }
            if (transform.position.x < finalPos2)
            {
                currentGoal = 1;
            }
        }
    }
}