﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    enum itemType
    {
        javeline,
        
    }

    private itemType type = itemType.javeline;
    public GameObject item;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //dir is the direction from the agent to player
    public void Attack(Vector2 dir)
    {
        GameObject i = Instantiate(item, transform.position, Quaternion.identity);
        i.transform.RotateAround(i.transform.position, Vector3.forward, Vector2.SignedAngle(Vector2.right, dir));

       if(type==itemType.javeline)
           i.GetComponentInChildren<JavelinController>().SetProjectilePoint((Vector2)transform.position+dir);
        
    }
}
