using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;
using UnityEngine.AI;

public class NavAgentSync : ActionTask<Transform>
{
    public BBParameter<NavMeshAgent> agentNavAgent;

    protected override void OnExecute()
    {
        if (agentNavAgent == null) EndAction(false);

        if (agentNavAgent != null)
        {
            agentNavAgent.value.nextPosition = agent.transform.position;
            agentNavAgent.value.SetDestination(agent.transform.position);
            agentNavAgent.value.velocity = Vector3.zero;
        }

        EndAction(true);
    }
}
