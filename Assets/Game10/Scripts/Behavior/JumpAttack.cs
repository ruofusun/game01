using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class JumpAttack : Action
{

    public SharedVector2 speed;
    public bool modifyGravity = false;
    public float gravityModifier = 1;

    Rigidbody2D rb2d;
    SpriteRenderer sp;

    TaskStatus status = TaskStatus.Running;

    public override void OnStart()
    {
        status = TaskStatus.Running;
        rb2d = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();

        if (rb2d && sp)
        {
            if (sp.flipX)
            {
                rb2d.velocity = speed.Value;
            }
            else
            {
                Vector2 temp = new Vector2(-speed.Value.x, speed.Value.y);
                rb2d.velocity = temp;
            }
        }
        else 
        {
            status = TaskStatus.Failure;
        }
    }


    public override TaskStatus OnUpdate()
    {
    
        //falling
        if(rb2d.velocity.y<0)
        { 
            if(modifyGravity)
            {
                rb2d.AddForce(new Vector2(0, -9.81f * gravityModifier));
            }
        }


        //check on ground
        Mover mover = GetComponent<Mover>();
        if(mover)
        { 
            if(mover.grounded&&rb2d.velocity.y<=0)
            {
                status = TaskStatus.Success;
            }
        }

        return status;
    }
}

