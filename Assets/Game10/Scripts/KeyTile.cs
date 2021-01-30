using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTile : MonoBehaviour
{

    public GameObject tp;
    public Vector3 tpPositionDistance = new Vector3(0.85f, 2.2f, 0f); 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if(other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Destroy(gameObject);
            Instantiate(tp, transform.position + tpPositionDistance, transform.rotation);

        }


    }
}

