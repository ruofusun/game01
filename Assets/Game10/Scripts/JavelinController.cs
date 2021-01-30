using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JavelinController : PropBase
{
    private Projectile _projectile;

    private Vector2 _dir;
    // Start is called before the first frame update
    void Start()
    {
        _projectile = GetComponent<Projectile>();
      
    }

    public void SetDir(Vector2 dir)
    {
       // _dir = dir;
       // _projectile.SetP3(_dir);
    }


    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
