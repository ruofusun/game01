using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class FreezeLayout : MonoBehaviour {
    [SerializeField] private bool isFrozen;
    public bool IsFrozen {
        get => isFrozen;
        set {
            isFrozen = value;
            OnValidate();
        }
    }

    private void OnValidate() {
        foreach (var layout in GetComponentsInChildren<LayoutGroup>()) {
            layout.enabled = isFrozen;
        }
        foreach (var layout in GetComponentsInChildren<ContentSizeFitter>()) {
            layout.enabled = isFrozen;
        }
        foreach (var layout in GetComponentsInChildren<AspectRatioFitter>()) {
            layout.enabled = isFrozen;
        }
    }
    
}
