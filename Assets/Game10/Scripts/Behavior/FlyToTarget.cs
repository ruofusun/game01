using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class FlyToTarget : Action
{
    public SharedVector2 target;
    private Rigidbody2D rigidbody2D;

    public float Offset = 0.25f;
    public SharedFloat Speed = 2f;


    public override void OnStart()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }


    public override TaskStatus OnUpdate()
    {
        if(target==null)
        {
            return TaskStatus.Failure;
        }
        var offset = target.Value - (Vector2)transform.position;
        if(offset.sqrMagnitude<Offset )
        {

            return TaskStatus.Success;
        }
        rigidbody2D.velocity = offset.normalized * Speed.Value;

        return TaskStatus.Running;


    }


}