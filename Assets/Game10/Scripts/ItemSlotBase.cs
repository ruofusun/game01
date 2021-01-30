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
            if (item != null)
                item.transform.SetParent(transform);
        }
    }

    public bool useCurrentChild = true;

    void OnEnable() {
        if (useCurrentChild)
            Item = GetComponentInChildren<Item>();
    }
}
