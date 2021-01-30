using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemDragContainer : ItemSlotBase {
    public UnityEvent onDragStart;
    public UnityEvent onDragEnd;

    public void Drag(Item item) {
        if (Item != null) return;
        Item = item;
        onDragStart.Invoke();
    }
    
    public void FinishDrag() {
        if (Item == null) return;
        onDragEnd.Invoke();
        Item = null;
    }
    
}
