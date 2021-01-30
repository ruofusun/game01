using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemDragContainer : ItemSlot {
    public bool instantiateItemOnDrag = false;
    public bool destroyDraggedItemOnFinish = true;
    
    public UnityEvent onDragStart;
    public UnityEvent onDragEnd;

    public void Drag(Item item) {
        if (instantiateItemOnDrag) item = Instantiate(item);
        Item = item;
        onDragStart.Invoke();
    }
    
    public void FinishDrag() {
        onDragEnd.Invoke();
        if (destroyDraggedItemOnFinish) Destroy(Item);
        Item = null;
    }
    
}
