using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;


public class TimeLimit : Decorator
{
    bool isFinished = false;
    public float maxTime = 2f;
    public float minTime = 1f;
    public bool WaitForTimeUp = false;

    public override bool CanExecute()
    {
        return !isFinished;
    }

    public override TaskStatus OverrideStatus()
    {
        if (isFinished) return TaskStatus.Success;
        return base.OverrideStatus();
    }

    public override void OnStart()
    {
        isFinished = false;
        StartCoroutine(nameof(timer));
    }

    IEnumerator timer() 
    {
        float waitTime = minTime == maxTime ? minTime : Random.Range(minTime, maxTime);
        yield return new WaitForSeconds(waitTime);
        isFinished = true;

    }

    public override void OnConditionalAbort()
    {
        StopCoroutine(nameof(timer));
        base.OnConditionalAbort();
    }

    public override void OnChildExecuted(TaskStatus childStatus)
    {
        base.OnChildExecuted(childStatus);
        if(childStatus== TaskStatus.Success&& !WaitForTimeUp) 
        {
            StopCoroutine(nameof(timer));
            isFinished = true;
        }

    }
}