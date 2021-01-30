using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class CraftPanel : MonoBehaviour {
    public CraftTable craftTable;
    
    [SerializeField]
    private ItemSlotBase[] recipeSlots;
    
    [SerializeField]
    private ItemDragContainer dragContainer;
    
    [SerializeField]
    private Transform transformPool;
    
    [SerializeField]
    private LayoutGroup layoutResults;

    void OnValidate() {
        if (recipeSlots != null && recipeSlots.Length != 9)
            Debug.LogError("[CraftPanel] Recipe Slots need a size of 9.", this);
    }

    #region Dragging

    public bool IsDraggingItem => dragContainer.Item != null;
    
    public void DragItemFrom([NotNull] ItemSlotBase itemSlotBase, bool copy) {
        if (IsDraggingItem) EndDragging();
        dragContainer.Drag(copy ? MakeItem(itemSlotBase.Item) : itemSlotBase.Item);
        if (!copy) ClearSlot(itemSlotBase);
    }

    public void PutDraggedItem([NotNull] ItemSlotBase itemSlotBase, bool copy) {
        itemSlotBase.Item = copy ? MakeItem(dragContainer.Item) : dragContainer.Item;
        if (!copy) EndDragging();
    }
    
    public void ExchangeDraggedItem([NotNull] ItemSlotBase itemSlotBase) {
        var tmpItem = itemSlotBase.Item;
        itemSlotBase.Item = dragContainer.Item;
        dragContainer.Item = tmpItem;
        if (dragContainer.Item == null) dragContainer.FinishDrag();
    }
    
    public void ClearSlot([NotNull] ItemSlotBase itemSlotBase) {
        RecycleItem(itemSlotBase.Item);
    }

    public void EndDragging() {
        RecycleItem(dragContainer.Item);
        dragContainer.FinishDrag();
    }

    #endregion

    #region Item Pool

    private readonly Dictionary<string, Stack<Item>> itemPools = new Dictionary<string, Stack<Item>>();

    private Item MakeItem(Item item) {
        if (item == null) return null;
        if (!itemPools.TryGetValue(item.craftText, out var pool))
            pool = (itemPools[item.craftText] = new Stack<Item>());
        return pool.PeekAndPop() ?? Instantiate(item);
    }
    
    private void RecycleItem(Item item) {
        if (item == null) return;
        itemPools[item.craftText]?.Push(item);
        item.transform.SetParent(transformPool);
    }

    #endregion

}
