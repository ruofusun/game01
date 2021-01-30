using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JavelinController : PropBase
{
    private Projectile _projectile;

   // private Vector2 _dir;
    // Start is called before the first frame update
    void Start()
    {
        _projectile = GetComponent<Projectile>();
      
    }

    //pass playerpos here
    public void SetProjectilePoint(Vector2 playerPos)
    {
        _projectile = GetComponent<Projectile>();
      _projectile.SetControlPoint(Vector2.zero, new Vector2(playerPos.x>0? 0.5f : -0.5f, 3),  new Vector2(playerPos.x-0.5f, 3 ), playerPos);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
