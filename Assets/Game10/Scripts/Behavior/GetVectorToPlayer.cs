using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;


public class GetVectorToPlayer :Action
{
    TaskStatus status = TaskStatus.Running;
    public PlayerController player;
    public SharedVector2 vecToPlayer;

    public override void OnStart()
    {
        if(player==null)
            player = Global.GetPlayer();
        if (player)//later get it from global 
        {
            Vector2 dir = player.transform.position - gameObject.transform.position;
            vecToPlayer.SetValue(dir);
            status = TaskStatus.Success;
        }
        else
        {
            status = TaskStatus.Failure;
        }
    }

    public override TaskStatus OnUpdate()
    {
        return status;
    }
}