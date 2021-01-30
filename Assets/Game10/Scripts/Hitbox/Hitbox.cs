using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    protected LayerMask targetLayerMask;
    protected LayerMask envLayerMask;
    
    // Start is called before the first frame update
    protected virtual void Start()
    {
        envLayerMask = LayerMask.NameToLayer("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected virtual void OnCollisionEnter2D(Collision2D other)
    {
        throw new NotImplementedException();
    }
}
