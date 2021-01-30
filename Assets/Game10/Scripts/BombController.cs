using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : PropBase
{

    public float explodeTimer = 3f;

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim=GetComponent<Animator>();
        OnUse();
    }

    // Update is called once per frame
    void Update()
    {
  
    }


    protected override void OnUse()
    {
        anim.SetTrigger("IsCountDown");
        StartCoroutine(nameof(ExplosionCountDown));
    }

    IEnumerator ExplosionCountDown()
    {
        yield return new WaitForSecondsRealtime(explodeTimer);
        anim.SetTrigger("IsActivate");
      //  Destroy(gameObject);
    }

    public void OnDeath()
    {
        //cause damage 
        Destroy(gameObject);
    }
}
