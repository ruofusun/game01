using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour{
    public string craftText;

    public void AlignToSlot(ItemSlotBase slot) {
        Transform trans = transform;
        trans.SetParent(slot.transform);
        trans.localPosition = Vector3.zero;
        trans.localScale = Vector3.one;
        trans.localRotation = Quaternion.identity;
    }
}
