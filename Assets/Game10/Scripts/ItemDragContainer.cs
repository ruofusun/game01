using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemDragContainer : ItemSlotBase {
    public UnityEvent onDragStart;
    public UnityEvent onDragEnd;

    protected override void OnChangeItem(Item oldItem, Item newItem) {
        base.OnChangeItem(oldItem, newItem);
        if (oldItem != null && newItem == null) onDragEnd.Invoke();
        if (newItem != null && oldItem == null) onDragStart.Invoke();
    }
    
}
