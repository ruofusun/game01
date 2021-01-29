using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game01/Item Table")]
public class ItemTable :  ScriptableObject, IDisposable {
    [SerializeField]
    private List<Item> items;

    private readonly Dictionary<string, Item> itemDict = new Dictionary<string, Item>();

    public Item this[string itemCraftText] => itemDict[itemCraftText];

    public IReadOnlyList<Item> Items => items;
    
    void OnEnable() {
        foreach (var item in items) {
            itemDict[item.craftText] = item;
        }
    }
    
    public void Dispose() {
        Destroy(this);
    }
}
