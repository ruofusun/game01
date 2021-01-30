using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
[DefaultExecutionOrder(-100)]
public class UIFollowCursor : MonoBehaviour {
    private RectTransform rectTransform;
    private Canvas canvas;

    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }

    void Update() {
         rectTransform.anchoredPosition = CursorAnchorPos();
    }
    
    // https://answers.unity.com/questions/1169455/convert-inputmouseposition-to-recttransform-pivot.html
    public Vector2 CursorAnchorPos()
    { 
        if (canvas.renderMode != RenderMode.ScreenSpaceOverlay && canvas.worldCamera != null)
        {
            //Canvas is in Camera mode
            RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, Input.mousePosition, canvas.worldCamera, out var anchorPos);
            return anchorPos;
        }
        else
        {
            //Canvas is in Overlay mode
            Vector2 anchorPos = Input.mousePosition - rectTransform.parent.position;
            Vector2 lossyScale = rectTransform.lossyScale;
            return anchorPos / lossyScale;
        }
    }
    
}
