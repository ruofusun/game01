using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockOne : BlockBase
{
    public Drop otherDrop;
    protected override Drop DropOnDestroy => Random.Range(0f, 1f) < 0.5f ? defaultDrop : otherDrop;
    
    // Start is called before the first frame update
    void Start()
    {
        _blockType = BlockType.one;
    }
    
}
