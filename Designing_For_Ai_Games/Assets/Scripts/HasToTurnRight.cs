using NodeCanvas.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasToTurnRight : ConditionTask
{
    public BBParameter<Transform> target;

    protected override bool OnCheck()
    {
        Vector3 localTarget = agent.transform.InverseTransformPoint(target.value.position);

        float angle = Mathf.Atan2(localTarget.x, localTarget.z) * Mathf.Rad2Deg;

        if (angle < 0) return false;
        else return true;
    }
}
