using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class CraftPanel : MonoBehaviour {
    public CraftTable craftTable;
    
    [SerializeField]
    private ItemSlot[] recipeSlots;
    
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
    
    public void StartDragging([NotNull] ItemSlot itemSlot) {
        dragContainer.Drag(MakeItem(itemSlot.Item));
    }

    public void PutDraggedItem([NotNull] ItemSlot itemSlot) {
        itemSlot.Item = MakeItem(dragContainer.Item);
    }
    
    public void EndDragging() {
        RecycleItem(dragContainer.Item);
        dragContainer.FinishDrag();
    }

    #endregion

    #region Item Pool

    private readonly Dictionary<string, Stack<Item>> itemPools = new Dictionary<string, Stack<Item>>();

    private Item MakeItem([NotNull] Item item) {
        if (!itemPools.TryGetValue(item.craftText, out var pool))
            pool = (itemPools[item.craftText] = new Stack<Item>());
        return pool.PeekAndPop() ?? Instantiate(item);
    }
    
    private void RecycleItem([NotNull] Item item) {
        itemPools[item.craftText]?.Push(item);
        item.transform.SetParent(transformPool);
    }

    #endregion

}
