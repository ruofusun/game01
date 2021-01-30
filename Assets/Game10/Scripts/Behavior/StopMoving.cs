using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class StopMoving : Action
{
    Rigidbody2D rigidbody2D;
    TaskStatus status = TaskStatus.Running;

    public override void OnStart()
    {
        
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = Vector2.zero;
        status = TaskStatus.Success;
        
    }

    public override TaskStatus OnUpdate()
    {
        return status;
    }

}
