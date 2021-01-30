using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBase : MonoBehaviour
{

  public enum BlockType
    {
        zero,
        one,
        special
    }
    protected BlockType _blockType = BlockType.zero;
    public GameObject blockContent;

    protected virtual Item GetItem()
    {
        return null;
    }

    protected virtual void OnCollisionEnter(Collision other)
    {
        throw new NotImplementedException();
    }
}
