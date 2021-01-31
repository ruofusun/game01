using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTile : MonoBehaviour
{

    public GameObject tp;
    public Vector3 tpPositionDistance = new Vector3(0.85f, 2.2f, 0f);
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.name == "Player")
        {
            Destroy(gameObject);
            Instantiate(tp, transform.position + tpPositionDistance, transform.rotation);
            //StartCoroutine(Timer(other.gameObject));

        }
        

    }
    //public IEnumerator Timer(GameObject player)//倒计时方法
    //{
    //    player.GetComponent<Renderer>().enabled = false;
    //    Vector3 levPosA = new Vector3(1.7f, 4.1f, 0f);
    //    Vector3 levPosB = new Vector3(36.7f, 4.1f, 0f);
    //    Vector3 levPosC = new Vector3(71.7f, 4.1f, 0f);
    //    Vector3 levPosD = new Vector3(106.7f, 4.1f, 0f);
    //    Vector3 levPosE = new Vector3(141.7f, 4.1f, 0f);
     
    //    if (0f< player.transform.position.x && player.transform.position.x < 35f) {
    //        player.transform.position = levPosB;
    //        Debug.Log("1a");
    //    }
    //    if (35f < player.transform.position.x && player.transform.position.x < 70f)
    //    {
    //        player.transform.position = levPosC;
    //        Debug.Log("1b");
    //    }
    //    if (70f < player.transform.position.x && player.transform.position.x < 105f)
    //    {
    //        player.transform.position = levPosD;
    //        Debug.Log("1c");
    //    }
    //    if (105f < player.transform.position.x && player.transform.position.x < 140f)
    //    {
    //        player.transform.position = levPosE;
    //        Debug.Log("1d");
    //    }
    //    if (140f < player.transform.position.x && player.transform.position.x < 175f)
    //    {
    //        player.transform.position = levPosA;
    //        Debug.Log("1e");
    //    }
    //    yield return new WaitForSeconds(0.8f);
    //    player.GetComponent<Renderer>().enabled = true;
    //}
}