using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EelMovement : EnemyActivate
{
    public AnimationCurve windUpCurve;
    public AnimationCurve snapCurve;
    private float lerpTimer;

    public float snapDistance;
    public float windupDistance;

    private Vector3 startPos;
    private Vector3 windupPos;
    private Vector3 endPos;

    private Vector3 toWindup;
    private Vector3 toEnd;

    bool windup = true;

    public float timeToAttack;
    private float waitTimer;

    public bool bossEel;
    BossFish fishScript;

    void Start()
    {
        if(bossEel)
        {
            fishScript = FindObjectOfType<BossFish>();
        }

        startPos = transform.position;

        //Gil's way to do eel movement
        //endPos = startPos;
        //endPos.y += snapDistance;

        //windupPos = startPos;
        //windupPos.y -= windupDistance;

        endPos = startPos + transform.up.normalized * snapDistance;
        windupPos = startPos - transform.up.normalized * windupDistance;
        
    }

    void Update()
    {
        toEnd = endPos - transform.position;
        if (bossEel || active)
        {
            toWindup = windupPos - transform.position;
        
            waitTimer += Time.deltaTime;
            if ((waitTimer >= timeToAttack && !bossEel) || (bossEel && fishScript.dashEels))
            {
                if (windup)
                {
                    lerpTimer += Time.deltaTime;
                    transform.position = Vector3.Lerp(startPos, windupPos, windUpCurve.Evaluate(lerpTimer));
                    if (toWindup.magnitude < 0.1)
                    {
                        windup = false;
                        lerpTimer = 0;
                    }
                }
                else
                {
                    lerpTimer += Time.deltaTime;
                    transform.position = Vector3.Lerp(windupPos, endPos, snapCurve.Evaluate(lerpTimer));
                    if (toEnd.magnitude < 0.1 && !bossEel)
                    {
                        fishScript.dashEels = false;
                        Destroy(gameObject);
                    }
                }
            }

        }
        if (bossEel)
        {
            if (toEnd.magnitude < snapDistance-5f && !fishScript.dashEels)
            {
                Destroy(gameObject);
            }

        }
    }
}
