﻿using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
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
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == targetLayerMask)
        {
           Destroy(other.gameObject);
            Destroy(transform.parent.gameObject);
        }

        if (other.gameObject.layer == envLayerMask)
        {
            Destroy(transform.parent.gameObject);
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
