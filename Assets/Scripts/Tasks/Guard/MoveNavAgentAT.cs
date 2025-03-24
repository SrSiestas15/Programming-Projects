using NodeCanvas.Framework;
using NodeCanvas.Tasks.Actions;
using UnityEngine;
using UnityEngine.AI;

public class MoveNavAgentAT : ActionTask
{
    public NavMeshAgent navAgent;
    public BBParameter<GameObject> destination;

    protected override void OnExecute()
    {
        navAgent.SetDestination(destination.value.transform.position);
    }

    protected override void OnUpdate()
    {
        if (!navAgent.pathPending)
        {
            if (navAgent.remainingDistance <= navAgent.stoppingDistance)
            {
                if (!navAgent.hasPath || navAgent.velocity.sqrMagnitude == 0)
                    EndAction(true);
            }
        }
    }

    protected override void OnStop()
    {
        navAgent.ResetPath();
    }
}
