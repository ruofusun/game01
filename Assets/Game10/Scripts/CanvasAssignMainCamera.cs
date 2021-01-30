using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Canvas))]
public class CanvasAssignMainCamera : MonoBehaviour {
    public bool assignWhenAlreadyAssigned = false;

    void Reset() => Assign();
    void OnValidate() => Assign();
    void OnEnable() => Assign();

    private void Assign() {
        var canvas = GetComponent<Canvas>();
        if (canvas.worldCamera == null || assignWhenAlreadyAssigned)
            canvas.worldCamera = Camera.main;
    }
    
}
