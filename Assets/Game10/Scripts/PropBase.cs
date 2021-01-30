using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropBase : MonoBehaviour
{
    public ItemProp prefabItem;

    protected virtual void OnTriggerEnter(Collider other)
    {
        
    }

    protected virtual void OnUse()
    {
        
    }
}
