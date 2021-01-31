using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBase : MonoBehaviour {
    public Drop defaultDrop;
    
    public enum BlockType
    {
        zero,
        one,
        special
    }
    protected BlockType _blockType = BlockType.zero;
    
    protected virtual Drop DropOnDestroy => defaultDrop;

    public void DestroyAndDrop() {
        if (DropOnDestroy != null) Drop.SpawnAtTransform(transform, Vector3.zero, DropOnDestroy);
        Destroy(gameObject);
    }
}
