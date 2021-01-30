using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftPanelController : MonoBehaviour {
    private CraftPanel panel;
    
    void Awake() {
        panel = FindObjectOfType<CraftPanel>();
        if (!panel) {
            Debug.LogError("[CraftPanelController] Cannot find Craft Panel in scene");
            enabled = false;
        }
    }

    void Update() {
        if (Input.GetMouseButtonDown(1)) {
            panel.IsPanelOpened = !panel.IsPanelOpened;
        }
    }
}
