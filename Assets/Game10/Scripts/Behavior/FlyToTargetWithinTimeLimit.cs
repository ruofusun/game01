using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class FlyToTargetWithTimelimit : Action
{
    public SharedVector2 target;
    private Rigidbody2D rigidbody2D;

    public float Offset = 0.25f;
    public float Speed = 2f;

    public float maxTime = 2f;
    public float minTime = 1f;
    bool timerUp = false;



    public override void OnStart()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        timerUp = false;
        StartCoroutine(nameof(Timer));
    }

    IEnumerator Timer()
    {
        float waitTime = minTime == maxTime ? minTime : Random.Range(minTime, maxTime);
        yield return new WaitForSeconds(waitTime);
        timerUp = true;
    }


    public override TaskStatus OnUpdate()
    {
        if (target == null)
        {
            return TaskStatus.Failure;
        }
        var offset = target.Value - (Vector2)transform.position;
        if (offset.sqrMagnitude < Offset||timerUp)
        {
            return TaskStatus.Success;
        }
        rigidbody2D.velocity = offset.normalized * Speed;

        return TaskStatus.Running;


    }

}
