﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    
    public Vector2 p0;

    public Vector2 p1;

    public Vector2 p2;

    public Vector2 p3;

    private Vector3 origin;

    public bool toRight = true;

    private bool canMove = false;
    
    // Start is called before the first frame update
    void Start()
    {
        origin = transform.position;

    }

 
    private float t;
    void Update()
    {
        if (canMove)
        {
            t += Time.deltaTime;
           
                Throw(t);
            
        }
    }

    public void Throw(float t)
    {
        Vector2 delta = CalculateBezierPoint(t, p0, p1, p2, p3);
        if (toRight)
        {
            if (transform.parent == null)
            {
                transform.position = origin + new Vector3(delta.x, delta.y, 0);
                transform.RotateAround(transform.position,Vector3.forward, 100*Time.deltaTime);
            }
            else
            {
                
                transform.parent.transform.position = origin + new Vector3(delta.x, delta.y, 0);
                transform.RotateAround(transform.position,Vector3.forward, 100*Time.deltaTime);
            }
        }
        else
        {
            if (transform.parent == null)
            {
                 transform.position = origin + new Vector3(delta.x, delta.y, 0);
                transform.RotateAround(transform.position,Vector3.forward, -100*Time.deltaTime);
            }
            else
            {
                
                transform.parent.transform.position = origin + new Vector3(delta.x, delta.y, 0);
                transform.RotateAround(transform.position,Vector3.forward, -100*Time.deltaTime);
            }
        }

    }
    public void SetThrowDirection(bool dir)
    {
        toRight = dir;
        if (!toRight)
        {
            transform.RotateAround(transform.position, Vector3.forward, 90);
        }
    }

    //what need to pass in is the relative value,for example p0 should be vector2.zero
    Vector2 CalculateBezierPoint(float t, Vector2 p0, Vector2 p1, Vector2 p2, Vector2 p3)
    {
        float u = 1-t;
        float tt = t*t;
        float uu = u*u;
        float uuu = uu * u;
        float ttt = tt * t;
 
        Vector2 p = uuu * p0; //first term
        p += 3 * uu * t * p1; //second term
        p += 3 * u * tt * p2; //third term
        p += ttt * p3; //fourth term
 
        return p;
    }

    //final point 

    public void SetControlPoint(Vector2 pp0, Vector2 pp1, Vector2 pp2, Vector2 pp3)
    {
        p0 = pp0;
        p1 = pp1;
        p2 = pp2;
        p3 = pp3;
        canMove = true;
        origin = transform.position;

    }
    
}
