using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
Currently controls enemy attacks AND active state bool
Will seperate these into different scripts in the future
TO DO - Fix Active and Camera Trigger Zone

*/

public class EnemyAttackAndActivate : MonoBehaviour
{
    public bool active = false;

    protected Rigidbody2D enemyRB;

    public List<GameObject> attacks;

    bool alreadyShot = false;

    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (active)
        {
            if (!alreadyShot)
            {
                StartCoroutine("EnemyShoot");
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Activate Trigger") //if an enemy collides with the activate trigger (in front of the camera)
        {
            active = true; //active is set to true
        }
    }

    IEnumerator EnemyShoot()
    {
        alreadyShot = true;
        Instantiate(attacks[Random.Range(0, attacks.Count)], transform.position, transform.rotation);
        yield
        return new WaitForSeconds(2);
        alreadyShot = false;
    }

}
