using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerPropController : MonoBehaviour {
    public Transform holdPoint;
    public PropBase initProp;
    
    private PropBase prop;
    private PropBase lastPropPrefab;

    private PlayerController player;
    
    private Inventory inventory;

    private void SetPropFromPrefab(PropBase propPrefab) {
        if (prop != null) Destroy(prop);
        if (propPrefab == null) {
            prop = null;
            return;
        }
        lastPropPrefab = propPrefab;
        prop = Instantiate(propPrefab, holdPoint, false);
        var trans = prop.transform;
        trans.localPosition = Vector3.zero;
        trans.localScale = Vector3.one;
        trans.localRotation = Quaternion.identity;
        if (trans.GetComponent<BombController>())
        {
            Rigidbody2D rb = trans.GetComponent<Rigidbody2D>();
            rb.gravityScale = 0;
            rb.isKinematic = true;
            trans.GetComponent<CircleCollider2D>().isTrigger = true;
        }
    }
    
    void Awake() {
        player = GetComponent<PlayerController>();
        inventory = Global.GetInventory();
        SetPropFromPrefab(initProp);
    }

    void Update() {
        if (inventory != null && inventory.prop != lastPropPrefab) {
            SetPropFromPrefab(inventory.prop);
        }

        if (Input.GetMouseButtonDown(0) && prop != null) {
            // ReSharper disable once ReplaceWithSingleAssignment.False
            bool canUse = false;
            if (player.IsGrounded && prop.allowUseOnGround) canUse = true;
            if (player.IsInAir && prop.allowUseInAir) canUse = true;
            if (canUse) {
                //bomb
                Transform trans = prop.transform;
                if (trans.GetComponent<BombController>())
                {
                    Rigidbody2D rb = trans.GetComponent<Rigidbody2D>();
                    rb.gravityScale = 1;
                    rb.isKinematic = false;
                    trans.GetComponent<CircleCollider2D>().isTrigger = false;
                }
                
                prop.Use();
                if(prop.animationTriggerOnUse!=String.Empty)
                player.PlayerAnimator.SetTrigger(prop.animationTriggerOnUse);
            }
        }
    }
    
}
