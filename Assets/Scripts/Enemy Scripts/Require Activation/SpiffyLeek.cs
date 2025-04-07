using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiffyLeek : EnemyActivate
{
    Vector3 newTransform;

    private float averageX;
    private float averageY;

    // Start is called before the first frame update
    void Start()
    {
        //CalcAvg();
        newTransform = new Vector3(averageX, averageY, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            CalcAvg();
            transform.position = newTransform;
        }
    }

    void CalcAvg()
    {
        averageX = (LeekMovement.leekTransform1.position.x + LeekMovement.leekTransform2.position.x) / 2;
        averageY = (LeekMovement.leekTransform1.position.y + LeekMovement.leekTransform2.position.y) / 2;
        newTransform.x = averageX;
        newTransform.y = averageY;
    }
}
