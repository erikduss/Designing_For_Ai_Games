using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;
using UnityEngine.AI;

public class StopAllMovement : ActionTask<Transform>
{
    public BBParameter<Rigidbody> agentRigidbody;
    public BBParameter<NavMeshAgent> agentNavAgent;

    protected override void OnExecute()
    {
        if(agentNavAgent == null && agentRigidbody == null) EndAction(false);

        if(agentNavAgent != null)
        {
            agentNavAgent.value.SetDestination(agent.transform.position);
            agentNavAgent.value.velocity = Vector3.zero;
        }

        if(agentRigidbody != null)
        {
            agentRigidbody.value.velocity = Vector3.zero;
        }

        EndAction(true);
    }
}
