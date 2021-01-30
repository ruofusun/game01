using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour
{

    public static PlayerController player;

    public static HPManager hpManager;


    public static PlayerController GetPlayer()
    {
        if (player == null)
            player = FindObjectOfType<PlayerController>();
        return player;
    }

    public static HPManager GetHpManager()
    {
        if (hpManager == null)
           hpManager = FindObjectOfType<HPManager>();
        return hpManager;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
