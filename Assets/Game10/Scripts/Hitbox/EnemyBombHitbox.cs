using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBombHitbox : EnemyHitbox
{
    protected override void Start()
    {
        base.Start();
        targetLayerMask = LayerMask.NameToLayer("Player");
    }

    protected override void OnCollisionEnter2D(Collision2D other)
    {
      
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == targetLayerMask)
        {
            Global.GetHpManager().ReduceValue();
        }
        if (other.gameObject.layer == envLayerMask)
        {
           //kill blocks
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
           Destroy(other.gameObject);
        }

    }
}
