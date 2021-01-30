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

    void Awake() {
        isOpened = gameObject.activeSelf;
    }

    void OnValidate() {
        if (recipeSlots != null && recipeSlots.Length != 9)
            Debug.LogError("[CraftPanel] Recipe Slots need a size of 9.", this);
    }

    private bool isOpened = false;
    public bool IsPanelOpened {
        get => isOpened;
        set {
            if (value) OpenPanel();
            else ClosePanel();
        }
    }
    
    public void OpenPanel() {
        isOpened = true;
        gameObject.SetActive(true);
        UpdateInventorySlots();
    }

    public void ClosePanel() {
        isOpened = false;
        gameObject.SetActive(false);
        UpdateInventory();
    }

    #region Crafting

    private void CheckCraftResult() {
        string craftText = "";
        foreach (var slot in recipeSlots) {
            craftText += slot.CraftText;
        }
        resultSlot.PropInView = craftTable[craftText];
    }

    private void UpdateInventorySlots() {
        
    }

    private void UpdateInventory() {
        
    }

    public void CraftForPlayer(PlayerController player) {
        if (player == null) return;
        
        foreach (var slot in recipeSlots) {
            RecycleItem(slot.Item);
            slot.Item = null;
        }

        var result = resultSlot.PropInView;

        UpdateInventory();
        UpdateInventorySlots();
        
        CheckCraftResult();
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
