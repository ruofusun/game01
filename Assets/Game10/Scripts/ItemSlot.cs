using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ItemSlot : ItemSlotBase {
    private Button button;
    private CraftPanel panel;

    public bool giveOnClick = false;
    public bool takeOnClick = false;
    public bool giveCopy = false;
    public bool takeCopy = false;

    void Awake() {
        button = GetComponent<Button>();
        panel = GetComponentInParent<CraftPanel>();
    }

    void OnEnable() {
        button.onClick.AddListener(OnClick);
    }

    void OnDisable() {
        button.onClick.RemoveListener(OnClick);
    }

    private void OnClick() {
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
