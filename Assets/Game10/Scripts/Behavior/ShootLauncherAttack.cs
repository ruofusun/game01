using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class ShootLauncherAttack : Action
{

    public SharedVector2 direction;
    public Launcher launcher;
    TaskStatus status = TaskStatus.Running;

    public override void OnStart()
    {
        status = TaskStatus.Running;
        
        if (launcher == null) launcher = gameObject.GetComponentInChildren<Launcher>();
        if(launcher)
        {
            launcher.Attack(direction.Value);
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
