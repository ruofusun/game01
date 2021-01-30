using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlotBase : MonoBehaviour {
    private Item item;
    public Item Item {
        get => item;
        set {
            item = value;
            item.transform.SetParent(transform);
            item.FillParent();
        }
    }

    public bool useCurrentChild = true;

    void OnEnable() {
        if (useCurrentChild)
            Item = GetComponentInChildren<Item>();
    }
}
