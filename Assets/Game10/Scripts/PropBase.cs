using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropBase : MonoBehaviour {
    public ItemProp prefabItem;
    public string animationTriggerOnUse;
    public bool allowUseInAir = true;
    public bool allowUseOnGround = true;

    protected virtual void OnUse() {}

    public void Use() => OnUse();
}
