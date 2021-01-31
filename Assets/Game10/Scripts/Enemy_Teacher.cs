using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Teacher : MonoBehaviour
{
    Animator ani;
    public Transform foot;
    public bool CanCheck;
    void Start()
    {
        CanCheck = false;
        ani = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D g_left = Physics2D.Raycast(foot.position, Vector2.down, 0.1f, LayerMask.GetMask("Ground"));
        if (CanCheck)
        {
            if (g_left.collider)
            {
                ani.SetTrigger("IsGround");
            }
        }

    }
    void changeChecck() {

        CanCheck = true;
    }
}
