using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour{
    public string craftText = ".";
    public Item originalPrefab;

    public void AlignToSlot(Transform slotTransform) {
        Transform trans = transform;
        trans.SetParent(slotTransform);
        trans.localPosition = Vector3.zero;
        trans.localScale = Vector3.one;
        trans.localRotation = Quaternion.identity;
    }

    void OnValidate() {
        if (originalPrefab == null)
            Debug.LogError($"[Item] {name}'s Original Prefab need to be set to the original prefab", this);
    }

}
