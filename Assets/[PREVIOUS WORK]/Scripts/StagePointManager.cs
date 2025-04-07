using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StagePointManager : MonoBehaviour
{
    public static float TotalStagePoints;

    public float stagePointValue;
    private TakeDamage enemyScript;

    void Start()
    {
        enemyScript = gameObject.GetComponent<TakeDamage>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyScript.health <= 0)
        {
            TotalStagePoints += stagePointValue;
        }
    }
}
