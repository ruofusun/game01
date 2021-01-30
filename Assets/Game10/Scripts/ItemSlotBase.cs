using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlotBase : MonoBehaviour {
    private Item item;
    public Item Item {
        get => item;
        set {
            OnChangeItem(item, value);
            item = value;
        }
    }

    public string CraftText => item == null ? "." : item.craftText;

    public bool useCurrentChild = true;

    void OnEnable() {
        if (useCurrentChild)
            Item = GetComponentInChildren<Item>();
    }

    protected virtual void OnChangeItem(Item oldItem, Item newItem) {
        if (newItem != null) newItem.AlignToSlot(transform);
    }
    
}
