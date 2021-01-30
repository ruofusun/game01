using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour{
    public string craftText;

    public void FillParent() {
        RectTransform rectTransform = GetComponent<RectTransform>();
        if (rectTransform != null) {
            rectTransform.anchorMin = Vector2.zero;
            rectTransform.anchorMax = Vector2.one;
            rectTransform.offsetMin = Vector2.zero;
            rectTransform.offsetMax = Vector2.zero;
            rectTransform.localScale = Vector3.one;
        }
    }
}
