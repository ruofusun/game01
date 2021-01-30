using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    [SerializeField] private Item[] initialItems;
    [SerializeField] private PropBase initialProp;
    [SerializeField] private float maxStamina = 5;
    [SerializeField] private float staminaRecoverSpeed = 1;
    [SerializeField] private float staminaCostSpeed = -1;

    [NonSerialized] public readonly List<Item> items = new List<Item>(9);
    [NonSerialized] public PropBase prop;
    [NonSerialized] public float stamina = 1;
    [NonSerialized] public bool isInBulletTime = false;

    private float StaminaChangeSpeed => isInBulletTime ? staminaCostSpeed : staminaRecoverSpeed;

    void Start() {
        foreach (var item in initialItems) {
            items.Add(item);
            if (items.Count >= 9) break;
        }
        prop = initialProp;
    }

    void Update() {
        stamina = Mathf.Clamp(stamina + Time.unscaledDeltaTime * StaminaChangeSpeed, 0, maxStamina);
    }
    
}
