using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WagonScript : EnemyActivate
{

    //projectile variables
    public GameObject bulletPrefab;
    public float diagonalAngle;

    public float minInterval;
    public float maxInterval;

    public Transform projectile1Transform;
    public Transform projectile2Transform;
    public Transform projectile3Transform;

    private float projectileInterval1;
    private float projectileTimer1;

    private float projectileInterval2;
    private float projectileTimer2;

    private float projectileInterval3;
    private float projectileTimer3;

    void Start()
    {
        projectileInterval1 = Random.Range(minInterval, maxInterval);
        projectileInterval2 = Random.Range(minInterval, maxInterval);
        projectileInterval3 = Random.Range(minInterval, maxInterval);
    }


    void Update()
    {
        if (active)
        {
            projectileTimer1 += Time.deltaTime;
            if (projectileTimer1 >= projectileInterval1)
            {
                //shoot bullet diagonally to the left
                GameObject bullet = Instantiate(bulletPrefab, projectile1Transform.position, transform.rotation); //instantiate bullet
                MoveDirection bulletScript = bullet.GetComponent<MoveDirection>(); //get move script
                bulletScript.runDirection = new Vector2(-1 * Mathf.Cos(Mathf.Deg2Rad * diagonalAngle), Mathf.Sin(Mathf.Deg2Rad * diagonalAngle)); //set move direction to specified angle

                projectileTimer1 = 0f;
                projectileInterval1 = Random.Range(minInterval, maxInterval);
            }

            projectileTimer2 += Time.deltaTime;
            if (projectileTimer2 >= projectileInterval2)
            {
                //shoot one bullet vertically
                GameObject bullet = Instantiate(bulletPrefab, projectile2Transform.position, transform.rotation); //instantiate bullet
                MoveDirection bulletScript = bullet.GetComponent<MoveDirection>(); //get move script
                bulletScript.runDirection = new Vector2(0, 1); //set move direction to vertical (up)
                 
                projectileTimer2= 0f;
                projectileInterval2 = Random.Range(minInterval, maxInterval);
            }

            projectileTimer3 += Time.deltaTime;
            if (projectileTimer3 >= projectileInterval3)
            {
                //shoot bullet diagonally to the right
                GameObject bullet = Instantiate(bulletPrefab, projectile3Transform.position, transform.rotation); //instantiate bullet
                MoveDirection bulletScript = bullet.GetComponent<MoveDirection>(); //get move script
                bulletScript.runDirection = new Vector2(Mathf.Cos(Mathf.Deg2Rad * diagonalAngle), Mathf.Sin(Mathf.Deg2Rad * diagonalAngle)); //set move direction to specified angle

                projectileTimer3 = 0f;
                projectileInterval3 = Random.Range(minInterval, maxInterval);
            }

        }

    }
}
