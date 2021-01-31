using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShovelController : PropBase {
    public bool isPlayer = true;
    
    private Animator animator;
    private bool blockFound = false;
    
    private static readonly int dig = Animator.StringToHash("Dig");

    public void EndUse() {
        blockFound = true;
    }

    protected override void OnUse() {
        blockFound = false;
        animator.SetTrigger(dig);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (blockFound) return;
        var block = other.attachedRigidbody?.GetComponent<BlockBase>();
        if (block == null) return;
        blockFound = true;
        if (isPlayer) Global.GetInventory()?.AddItem(block.GetItem());
        Destroy(block.gameObject);
    }

    void Awake() {
        animator = GetComponentInChildren<Animator>();
    }
}
