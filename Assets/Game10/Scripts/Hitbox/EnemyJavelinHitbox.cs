using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJavelinHitbox : EnemyHitbox
{
    protected override void Start()
    {
        base.Start();
        targetLayerMask = LayerMask.NameToLayer("Player");
    }
    protected override void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == targetLayerMask)
        {
            Global.GetHpManager().ReduceValue();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
