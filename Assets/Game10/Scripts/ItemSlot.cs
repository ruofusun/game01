using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : ItemSlotBase {
    private CraftPanel panel;

    public bool giveOnClick = false;
    public bool takeOnClick = false;
    public bool giveCopy = false;
    public bool takeCopy = false;

    void Awake() {
        panel = GetComponentInParent<CraftPanel>();
    }

    public void OnClick() {
        if ((Item == null || takeCopy) && panel.IsDraggingItem && takeOnClick) {  // take
            panel.PutDraggedItem(this, takeCopy);
        }
        else if (Item != null && (!panel.IsDraggingItem || giveCopy) && giveOnClick) {
            panel.DragItemFrom(this, giveCopy);
        }
        else if (Item != null && panel.IsDraggingItem && giveOnClick && takeOnClick) {
            panel.ExchangeDraggedItem(this);
        }
    }

}
