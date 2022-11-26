using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Timers;

public class WaitSeconds : ActionTask
{
    public BBParameter<float> waitTime;
    private bool timerDone = false;

    protected override void OnExecute()
    {
        timerDone = false;
        StartCoroutine(WaitTimer(waitTime.value));
    }

    protected override void OnUpdate()
    {
        if (timerDone)
        {
            EndAction();
            return;
        }
    }

    private IEnumerator WaitTimer(float waitingTime)
    {
        yield return new WaitForSeconds(waitingTime);
        timerDone = true;
    }
}
