using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JavelinController : PropBase
{
    private Projectile _projectile;
    
    //private static readonly int dig = Animator.StringToHash("Dig");

   // private Vector2 _dir;
    // Start is called before the first frame update
    void Start()
    {
        _projectile = GetComponent<Projectile>();
      
    }
    protected override void OnUse()
    {
        PlayerController playerController = Global.GetPlayer();
        if (playerController.faceRight)
        {
            PlayerSetProjectilePoint((Vector2)transform.position+ new Vector2(7,3));
        }
        else
        {
            PlayerSetProjectilePoint((Vector2)transform.position+ new Vector2(-7,3));
        }


    }
    //pass playerpos here
    public void SetProjectilePoint(Vector2 playerPos)
    {
        _projectile = GetComponent<Projectile>();
        _projectile.SetThrowDirection(playerPos.x > transform.position.x ? false : true);
        Vector2 delta = playerPos -(Vector2) transform.position;
        _projectile.SetControlPoint(Vector2.zero, new Vector2(delta.x>0? 0.5f : -0.5f, 3),  new Vector2(delta.x < 0? delta.x+0.5f:delta.x-0.5f, 3 ), delta);
    }

    public void PlayerSetProjectilePoint(Vector2 des)
    {
        gameObject.transform.parent = null;
        _projectile = GetComponent<Projectile>();
       // transform.RotateAround(transform.position, Vector3.forward, 90);
        _projectile.SetThrowDirection(des.x > transform.position.x ? false : true);
        _projectile.SetControlPoint(Vector2.zero, new Vector2(des.x>transform.position.x? 0.5f : -0.5f, 3),  new Vector2(des.x-0.5f, 3 ),des);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
