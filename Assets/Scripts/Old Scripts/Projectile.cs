using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector3 target;
    private float moveSpeed;
    private float trajectoryMaxHeight;

    private AnimationCurve trajectoryAnimationCurve;
    private AnimationCurve axisCorrectionAnimationCurve;

    private Vector3 trajectoryStartPoint;

    private void Start()
    {
        trajectoryStartPoint = transform.position;
    }

    private void Update()
    {
        UpdateProjectilePosition();
    }

    private void UpdateProjectilePosition()
    {

        Vector3 trajectoryRange = target - trajectoryStartPoint;
        if (trajectoryRange.x < 0)
        {
            moveSpeed = -moveSpeed;
        }

        Debug.Log(trajectoryRange);

        float nextPositionX = transform.position.x + moveSpeed * Time.deltaTime;
        float nextPositionXNormalized = (nextPositionX - trajectoryStartPoint.x) / trajectoryRange.x;

        float nextPositionYNormalized = trajectoryAnimationCurve.Evaluate(nextPositionXNormalized);

        float nextPositionYCorrectionNormalized = axisCorrectionAnimationCurve.Evaluate(nextPositionXNormalized);
        float nextPositionYCorrectionAbsolute = nextPositionYCorrectionNormalized * trajectoryRange.y;
        
        float nextPositionY = trajectoryStartPoint.y + nextPositionYNormalized * trajectoryMaxHeight + nextPositionYCorrectionAbsolute;

        Vector3 newPosition = new Vector3(nextPositionX, nextPositionY, 0);

        transform.position = newPosition;
    }

    public void InitializeProjectile(Vector3 target, float moveSpeed, float trajectoryMaxHeight)
    {
        this.target = target;
        this.moveSpeed = moveSpeed;

        float xDistanceToTarget = target.x - transform.position.x;
        this.trajectoryMaxHeight = trajectoryMaxHeight;
    } 

    public void InitializeAnimationCurves(AnimationCurve trajectoryAnimationCurve, AnimationCurve axisCorrectionAnimationCurve)
    {
        this.trajectoryAnimationCurve = trajectoryAnimationCurve;
        this.axisCorrectionAnimationCurve = axisCorrectionAnimationCurve;

    }
}
