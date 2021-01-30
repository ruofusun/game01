using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockOne : BlockBase
{
    public GameObject secondBlockContent;
    
    // Start is called before the first frame update
    void Start()
    {
        _blockType = BlockType.one;
    }

    protected override void OnCollisionEnter(Collision other)
    {
        base.OnCollisionEnter(other);
    }

    public override Item GetItem()
    {
        if (Random.Range(0f, 1f) < 0.5f)
        {
            return secondBlockContent.GetComponent<Item>();
        }
        else
        {
            return blockContent.GetComponent<Item>();
        }
    }
}
