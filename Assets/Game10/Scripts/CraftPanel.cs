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
    private Transform itemPool;
    
    [SerializeField]
    private PropSlot resultSlot;

    void OnValidate() {
        if (recipeSlots != null && recipeSlots.Length != 9)
            Debug.LogError("[CraftPanel] Recipe Slots need a size of 9.", this);
    }

    #region Crafting

    private void CheckCraftResult() {
        string craftText = "";
        foreach (var slot in recipeSlots) {
            craftText += slot.CraftText;
        }
        resultSlot.PropInView = craftTable[craftText];
    }

    #endregion

    #region Dragging

    public bool IsDraggingItem => dragContainer.Item != null;
    
    public void DragItemFrom([NotNull] ItemSlotBase itemSlotBase, bool copy) {
        dragContainer.Item = ItemFrom(itemSlotBase, copy);
        CheckCraftResult();
    }

    public void PutDraggedItem([NotNull] ItemSlotBase itemSlotBase, bool copy) {
        itemSlotBase.Item = ItemFrom(dragContainer, copy);
        CheckCraftResult();
    }
    
    public void ExchangeDraggedItem([NotNull] ItemSlotBase itemSlotBase) {
        var tmpItem = itemSlotBase.Item;
        itemSlotBase.Item = dragContainer.Item;
        dragContainer.Item = tmpItem;
        CheckCraftResult();
    }
    
    public void EndDragging() {
        if (!IsDraggingItem) return;
        RecycleItem(dragContainer.Item);
        dragContainer.Item = null;
    }

    private Item ItemFrom(ItemSlotBase itemSlot, bool copy) {
        var result = copy ? MakeItem(itemSlot.Item) : itemSlot.Item;
        if (!copy) itemSlot.Item = null;
        return result;
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
        if (!itemPools.TryGetValue(item.craftText, out var pool))
            pool = (itemPools[item.craftText] = new Stack<Item>());
        pool.Push(item);
        item.transform.SetParent(itemPool);
    }

    #endregion

}
