﻿using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game01/Craft Table")]
public class CraftTable : ScriptableObject, IDisposable {
    [Serializable]
    private struct CraftTableParameters {
        public string recipe;
        public PropBase result;
    }
    
    [SerializeField]
    private CraftTableParameters[] crafts;
    
    private readonly Dictionary<string, List<PropBase>> dictCrafts = new Dictionary<string, List<PropBase>>();

    public PropBase this[string craftText] {
        get {
            if (dictCrafts.TryGetValue(craftText, out var list) && list.Count != 0)
                return list[0];
            return null;
        }
    }
    
    public void AddCraft(string recipe, PropBase result) {
        recipe = recipe.PadRight(9, '.').Substring(0, 9);
        if (!dictCrafts.TryGetValue(recipe, out var listResult)) listResult = dictCrafts[recipe] = new List<PropBase>();
        listResult.Add(result);
    }
    
    public void RemoveCraft(string recipe, PropBase result) {
        if (dictCrafts.TryGetValue(recipe, out var listResult)) {
            listResult.Remove(result);
        }
    }
    
    void OnEnable() {
        if (crafts == null) return;
        foreach (var craft in crafts) {
            AddCraft(craft.recipe, craft.result);
        }
    }

    public void Dispose() {
        Destroy(this);
    }
}
