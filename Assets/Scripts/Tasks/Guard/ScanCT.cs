using NodeCanvas.Framework;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class ScanCT : ConditionTask
{
    public LayerMask scanLayers = -1;
    public float scanRadius = 1f;

    public BBParameter<GameObject> currentTarget;

    Collider[] colliders;

    protected override void OnEnable()
    {
    }

    protected override bool OnCheck()
    {
        colliders = null;
        colliders = Physics.OverlapSphere(agent.transform.position, scanRadius, scanLayers);

        float currentDistance;
        GameObject currentGameObject = null;
        float bestDistance = Mathf.Infinity;

        foreach (Collider collider in colliders)
        {
            currentDistance = (agent.transform.position - collider.gameObject.transform.position).magnitude;
            if (currentDistance < bestDistance)
            {
                bestDistance = currentDistance;
                currentGameObject = collider.gameObject;
            } 
        }

        if(currentGameObject != null)
        {
            currentTarget.value = currentGameObject;
        }

        if (colliders.Length == 0) return false;
        else return true;
    }
}
