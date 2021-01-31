using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine.SceneManagement;

public class HPManager : MonoBehaviour
{

    public int hpFullValue = 3;

    public  int currentValue = 3;

    List<HeartContainer> containers;
    // Start is called before the first frame update
    void Start()
    {
        containers = GetComponentsInChildren<HeartContainer>().ToList();
    }


    [Button]
    public void AddValue() 
    {
        if(currentValue<3)
        {
            currentValue++;
            //should paint currentvalue-1 in the list
            PaintHeartContainer(true);
        }
    }


    [Button]
    public void ReduceValue() 
    {
        if(currentValue>0)
        {
            currentValue--;
            //should paint currentvalue in the list
            PaintHeartContainer(false);
        }
        if(currentValue==0)
        {
            SceneManager.LoadScene("MainPage");
            Debug.Log("should die now");
        }
    }




    public void PaintHeartContainer(bool addvalue) 
    {
        if(addvalue)
        {
            containers[currentValue - 1].PaintFull();
        }
        else 
        {
            containers[currentValue].PaintEmpty();
        }

    }
}
