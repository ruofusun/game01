using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{

    public bool grounded = false;
    public float rayDistance = 0.2f;
    public Transform footPos;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (footPos)
        {
            // Debug.DrawRay(transform.position, Vector2.down * rayDistance, Color.white);
            RaycastHit2D groundCheck = Physics2D.Raycast(footPos.position, Vector2.down, rayDistance, LayerMask.GetMask("Ground"));
            RaycastHit2D platformCheck = Physics2D.Raycast(footPos.position, Vector2.down, rayDistance, LayerMask.GetMask("Platform"));
            if (groundCheck.collider || platformCheck.collider)
            {
                grounded = true;
            }
            else
            {
                grounded = false;
            }
        }
    }
}