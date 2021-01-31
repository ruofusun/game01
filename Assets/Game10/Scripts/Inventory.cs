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

    public float StanimaPercentage => stamina / maxStamina;

    private float StaminaChangeSpeed => isInBulletTime ? staminaCostSpeed : staminaRecoverSpeed;

    public void AddItem(Item item) {
        if (items.Count < 9) items.Add(item);
    }

    private static Inventory instance;
    public static Inventory Inst {
        get {
            if (instance == null)
                instance = FindObjectOfType<Inventory>();
            return instance;
        }
    }

    void Awake() {
        instance = this;
    }

    void Start() {
        foreach (var item in initialItems) {
            items.Add(item);
            if (items.Count >= 9) break;
        }
        if (initialProp != null)
            prop = initialProp;
    }

    void Update() {
        stamina = Mathf.Clamp(stamina + Time.unscaledDeltaTime * StaminaChangeSpeed, 0, maxStamina);
    }
    
}
