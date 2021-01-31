using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour {
    public Item item;

    void OnTriggerEnter2D(Collider2D other) {
        if (!other.GetComponent<PlayerController>()) return;
        if (item != null) {
            Global.GetInventory()?.AddItem(item);
        }
        Destroy(gameObject);
    }

    public static Drop SpawnRelativeToPlayer(Vector3 relativePosition, Drop drop) {
        return SpawnAtTransform(Global.GetPlayer().transform, relativePosition, drop);
    }

    public static Drop SpawnAtTransform(Transform trans, Vector3 relativePosition, Drop drop) {
        return Instantiate(drop, trans.position + relativePosition, Quaternion.identity);
    }

}
