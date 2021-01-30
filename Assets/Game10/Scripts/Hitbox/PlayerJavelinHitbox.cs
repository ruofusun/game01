using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJavelinHitbox : PlayerHitbox
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        targetLayerMask = LayerMask.NameToLayer("Enemy");
    }


    protected override void OnCollisionEnter2D(Collision2D other)
    {
      
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
