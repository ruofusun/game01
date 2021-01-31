using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalAni : MonoBehaviour
{

    public GameObject finalAnimp4;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")
        {
            Time.timeScale = 1f;

            finalAnimp4.SetActive(true);
        }
        
    }
}
