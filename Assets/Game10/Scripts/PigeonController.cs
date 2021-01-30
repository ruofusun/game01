using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PigeonController : MonoBehaviour
{
    public GameObject bomb;
    public float bombCD = 3f;
    public bool canThrow = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private bool coroutineStarted = false;
    void Update()
    {
        RaycastHit2D r_player = Physics2D.Raycast(transform.position, Vector2.down, 10f, LayerMask.GetMask("Player"));
        if (r_player.collider&& !coroutineStarted)
        {
            coroutineStarted = true;
            StartCoroutine(nameof(ThrowBomb));
        }

    }

    IEnumerator ThrowBomb()
    {
      //  if (canThrow)
      //  {
          //  canThrow = false;
            Instantiate(bomb, transform.position, quaternion.identity);
       // }
        yield return new WaitForSecondsRealtime(bombCD);
      //  canThrow = true;
        coroutineStarted = false;
    }

}
