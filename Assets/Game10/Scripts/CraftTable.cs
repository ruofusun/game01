using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Game01/Craft Table")]
public class CraftTable : ScriptableObject, IDisposable {
    public string recipe;
    public PropBase result;

    public static CraftTable Create(string recipe, PropBase result) {
        var obj = CreateInstance<CraftTable>();
        obj.recipe = recipe;
        obj.result = result;
        return obj;
    }

    public void Dispose() {
        Destroy(this);
    }
}
