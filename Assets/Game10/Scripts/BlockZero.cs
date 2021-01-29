using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BlockZero: BlockBase
{
    private void Start()
    {
        _blockType = BlockType.zero;
    }

    protected override void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Shovel"))
        {
            Instantiate(blockContent, transform.position, quaternion.identity);
        }
    }
    
}
