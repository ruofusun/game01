using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TpControl : MonoBehaviour
{
    public Animator ani;
    //Vector3 vector3;
    public Vector3 birthPoint;
    public Vector3 tpDistance;


    private void Start()
    {
       // this.gameObject.SetActive(false);
    }
    
    /*
    public void AppearTp(bool isAppear,Vector3 targetVector3) {
        vector3 = targetVector3;
        this.gameObject.SetActive(isAppear);
        if (gameObject.activeInHierarchy == true)
        {
            ani.SetBool("IsStart", true);
        }

    }
    */

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            ani.SetBool("IsTp", true);

            birthPoint += tpDistance;
        }
    }

    public  void ChangeScene() {
        Global.GetPlayer().transform.position = birthPoint;
    }

}
