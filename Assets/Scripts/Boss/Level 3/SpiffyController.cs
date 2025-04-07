using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiffyController : MonoBehaviour
{
    GameObject spawnedLeek;

    public void SpawnCereal(List<GameObject> cereals, float sprayWidth) //instantiates cereals at specific angles
    {
        float newAngle = 0;
        float currentCereal = 0;

        foreach (GameObject cereal in cereals)
        {
            currentCereal++;
            newAngle = ((0 - sprayWidth/2) + ((sprayWidth / (cereals.Count + 1)) * currentCereal));
            Debug.Log(newAngle);
            Instantiate(cereal, transform.position, Quaternion.Euler(new Vector3(0, 0, newAngle)));
            Debug.Log(currentCereal);
            Debug.Log(cereals.Count);

        }
    }

    public void SpawnWaffles(GameObject waffle, float speed, Transform waffleTransform)
    {
        GameObject currentWaffle = Instantiate(waffle, waffleTransform.position, Quaternion.identity);
        currentWaffle.GetComponent<MoveDirection>().speed = speed;
    }

    public void activateObject(GameObject gameObject, bool turnOn)
    {
        gameObject.SetActive(turnOn);
    }

}
