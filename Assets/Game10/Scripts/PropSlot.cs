using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropSlot : MonoBehaviour
{
    private PropBase prop;
    private ItemProp item;
    public PropBase PropInView {
        get => prop;
        set {
            if (prop == value) return;
            if (item != null) Destroy(item.gameObject);
            prop = value;
            if (prop != null && prop.prefabItem != null) {
                item = Instantiate(prop.prefabItem);
                item.AlignToSlot(transform);
            }
        }
    }

}
