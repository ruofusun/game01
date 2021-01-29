using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockOne : BlockBase
{
    
    // Start is called before the first frame update
    void Start()
    {
        _blockType = BlockType.one;
    }

    protected override void OnCollisionEnter(Collision other)
    {
        base.OnCollisionEnter(other);
    }
}
