
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class FaceTarget : Action
{
    TaskStatus status = TaskStatus.Running;
    public GameObject target;



    public override void OnStart()
    {
        if (target == null)
        {
            target = Global.GetPlayer().gameObject;
        }
        if (target==null)
        {
            status = TaskStatus.Failure;
        }
        else
        {
            FlipSprite();
        }
    }


    public void FlipSprite() 
    {
        if (target.transform.position.x > transform.position.x)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        status = TaskStatus.Success;

    }
    public override TaskStatus OnUpdate()
    {
        //  FlipSprite();
        return status;
    }
}