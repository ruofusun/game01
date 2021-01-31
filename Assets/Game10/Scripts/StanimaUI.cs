using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StanimaUI : MonoBehaviour {
    private Inventory inventory;

    public Image fillImage;
    
    void Start() {
        inventory = Global.GetInventory();
    }

    void Update() {
        fillImage.fillAmount = inventory.StanimaPercentage;
    }
    
}
