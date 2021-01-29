using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : PropBase
{

    public Vector2 p0;

    public Vector2 p1;

    public Vector2 p2;

    public Vector2 p3;

    private Vector3 origin;

    private bool toRight = true;
    // Start is called before the first frame update
    void Start()
    {
        origin = transform.position;
    }

    private float t;
    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        if (t<1)
        {
            Throw(t);
        }
    }


    public void Throw(float t)
    {
        Vector2 delta =  CalculateBezierPoint(t, p0, p1, p2, p3);
        if (toRight)
        {
            transform.position = origin + new Vector3(delta.x, delta.y, 0);
        }
        else
        {
            transform.position = origin + new Vector3(-delta.x, delta.y, 0);
        }

    }

    public void SetThrowDirection(bool dir)
    {
        toRight = dir;
    }

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

    protected override void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
