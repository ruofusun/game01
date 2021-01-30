using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class CraftPanel : MonoBehaviour {
    public CraftTable craftTable;
    
    [SerializeField]
    private ItemSlotBase[] inventorySlots;
    
    [SerializeField]
    private ItemSlotBase[] recipeSlots;
    
    [SerializeField]
    private ItemDragContainer dragContainer;
    
    [SerializeField]
    private Transform itemPool;
    
    [SerializeField]
    private PropSlot resultSlot;

    public float minimumStaminaToOpen = 1;

    private Inventory inventory;

    void Awake() {
        isOpened = gameObject.activeSelf;
        inventory = Global.GetInventory();
    }

    void OnValidate() {
        if (recipeSlots != null && recipeSlots.Length != 9)
            Debug.LogError("[CraftPanel] Recipe Slots need a size of 9.", this);
    }
    
    void Update() {
        if (ShouldClosePanel) {
            ClosePanel();
        }
    }

    #region Panel Open Close

    private bool isOpened = false;
    public bool IsPanelOpened {
        get => isOpened;
        set {
            if (value) OpenPanel();
            else ClosePanel();
        }
    }

    private bool CanOpenPanel => inventory != null && inventory.stamina > minimumStaminaToOpen;
    private bool ShouldClosePanel => inventory == null || inventory.stamina < Mathf.Epsilon;
    
    public void OpenPanel() {
        if (!CanOpenPanel) return;
        isOpened = true;
        gameObject.SetActive(true);
        inventory.isInBulletTime = true;
        Time.timeScale = 0;
        UpdateInventorySlots();
    }

    public void ClosePanel() {
        isOpened = false;
        gameObject.SetActive(false);
        Time.timeScale = 1;
        if (inventory != null) inventory.isInBulletTime = false;
        UpdateInventory();
    }
    
    #endregion

    #region Crafting

    private void CheckCraftResult() {
        string craftText = "";
        foreach (var slot in recipeSlots) {
            craftText += slot.CraftText;
        }
        resultSlot.PropInView = craftTable[craftText];
    }

    private void UpdateInventorySlots() {
        if (inventory == null) return;
        for (int i = 0; i < inventorySlots.Length; ++i) {
            inventorySlots[i].Item = i < inventory.items.Count ? MakeItem(inventory.items[i]) : null;
        }
        for (int i = 0; i < recipeSlots.Length; ++i) {
            recipeSlots[i].Item = null;
        }
    }

    private void UpdateInventory() {
        if (inventory == null) return;
        inventory.items.Clear();
        foreach (var slot in inventorySlots) {
            if (slot.Item == null) continue;
            inventory.items.Add(slot.ItemPrefab);
            RecycleItem(slot.Item);
        }
        foreach (var slot in recipeSlots) {
            if (slot.Item == null) continue;
            inventory.items.Add(slot.ItemPrefab);
            RecycleItem(slot.Item);
        }
    }

    public void Craft() {
        foreach (var slot in recipeSlots) {
            RecycleItem(slot.Item);
            slot.Item = null;
        }

        inventory.prop = resultSlot.PropInView;
        resultSlot.PropInView = null;

        ClosePanel();
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
