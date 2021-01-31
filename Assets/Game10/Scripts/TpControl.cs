using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TpControl : MonoBehaviour
{
    public Animator ani;
    //Vector3 vector3;
    public Vector3 tpDistance = new Vector3(10f, 0f, 0f);
    public Vector3 cameraMove = new Vector3(35f, 0f, 0f);
    public Transform maincam;


    private void Start()
    {
       // this.gameObject.SetActive(false);
       maincam = GameObject.Find("Main Camera").GetComponent<Transform>();
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

        }
    }

    public void PlayerDisappear()

    {
        Global.GetPlayer().GetComponent<SpriteRenderer>().enabled = false;

    }

    public void ChangeScene() {
        maincam.transform.position += cameraMove;
        Global.GetPlayer().transform.position = maincam.transform.position + tpDistance;
        Global.GetPlayer().GetComponent<SpriteRenderer>().enabled = true;
        Destroy(gameObject);
    }

}
