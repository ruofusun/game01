using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreezeMapCreater : MonoBehaviour
{

    string levelE08 = "nnnnnnnnnnnnnnn";
    string levelE07 = "nnnnnnnnnnnnnnn";
    string levelE06 = "nnnnnnnn1101nnn";
    string levelE05 = "nnnnnnnnnnnnnnn";
    string levelE04 = "nnnnnnnnnnnnnnn";
    string levelE03 = "nnnnn1nnnnnnnnn";
    string levelE02 = "012101112110102";
    string levelE01 = "10221111111?022";

    string levelD08 = "nnnnnnnnnnnnnnn";
    string levelD07 = "nnnnnnnnnnnnnnn";
    string levelD06 = "nnnnnnnn1101nnn";
    string levelD05 = "nnnnnnnnnnnnnnn";
    string levelD04 = "nnnnnnnnnnnnnnn";
    string levelD03 = "nnnnn1nnnnnnnnn";
    string levelD02 = "012101112110102";
    string levelD01 = "10221111111?022";

    string levelC08 = "nnnnnnnnnnnnnnn";
    string levelC07 = "nnnnnnnnnnnnnnn";
    string levelC06 = "nnnnnnnn1101nnn";
    string levelC05 = "nnnnnnnnnnnnnnn";
    string levelC04 = "nnnnnnnnnnnnnnn";
    string levelC03 = "nnnnn1nnnnnnnnn";
    string levelC02 = "012101112110102";
    string levelC01 = "10221111111?022";

    string levelB08 = "nnnnnnnnnnnnnnn";
    string levelB07 = "nnnnnnnnnnnnnnn";
    string levelB06 = "nnnnnnnn1101nnn";
    string levelB05 = "nnnnnnnnnnnnnnn";
    string levelB04 = "nnnnnnnnnnnnnnn";
    string levelB03 = "nnnnn1nnnnnnnnn";
    string levelB02 = "01210111211010?";
    string levelB01 = "10221111111?022";

    string levelA08 = "nnnnnnnnnnnnnnn";
    string levelA07 = "nnnnnnnnnnnnnnn";
    string levelA06 = "nnnnnnnn1101nnn";
    string levelA05 = "nnnnnnnnnnnnnnn";
    string levelA04 = "nnnnnnnnnnnnnnn";
    string levelA03 = "nnnnn1nnnnnnnnn";
    string levelA02 = "01210111211010?";
    string levelA01 = "10221111111?022";

    //关卡所有砖块，自己定义一下排列

    GameObject b0;
    GameObject b1;
    GameObject b2;
    GameObject key;
    GameObject wall;
    GameObject ground;

    //0:0   1:1     2:倒过来的1     ?:? n:null
    Transform map;
    GameObject camera;

    private void Awake()
    {
        b0 = GameObject.Find("Block1");
        b1 = GameObject.Find("Block0");
        b2 = GameObject.Find("Block2");
        key = GameObject.Find("Key");
        wall = GameObject.Find("Wall");
        ground = GameObject.Find("Ground");

        map = GameObject.Find("MapBreeze").transform;
        camera = GameObject.Find("Main Camera");

    }

    void Start()
    {
        //levelA
        CreatLevel(levelA01, levelA02,levelA03,levelA04,levelA05,levelA06,levelA07,levelA08,0.0f);
        //levelB
        CreatLevel(levelA01, levelA02, levelA03, levelA04, levelA05, levelA06, levelA07, levelA08, 35f);
        //levelC
        CreatLevel(levelA01, levelA02, levelA03, levelA04, levelA05, levelA06, levelA07, levelA08, 70f);
        //levelD
        CreatLevel(levelA01, levelA02, levelA03, levelA04, levelA05, levelA06, levelA07, levelA08, 105f);
        //levele
        CreatLevel(levelA01, levelA02, levelA03, levelA04, levelA05, levelA06, levelA07, levelA08, 140f);
    }

    void Update()
    {

    }

    public void CreatMapList(string str, float heigh, float thisPoint)
    {
        GameObject go;//临时
        GameObject wallTemp;
        GameObject groundTemp;
        Transform tran;
        for (int i = 0; i < str.Length; i++)
        {
            if (str[i] == '0') go = GameObject.Instantiate<GameObject>(b0);
            else if (str[i] == '1') go = GameObject.Instantiate<GameObject>(b1);
            else if (str[i] == '2') go = GameObject.Instantiate<GameObject>(b2);
            else if (str[i] == '?') go = GameObject.Instantiate<GameObject>(key);
            else go = new GameObject();
            Destroy(go.GetComponent<Rigidbody2D>());
            go.transform.SetParent(map);
            go.transform.position = new Vector3(thisPoint + 1.7f * i, heigh, 0);
            tran = go.transform;
            if (heigh == 0 && i==0)
            {
                wallTemp = GameObject.Instantiate<GameObject>(wall, map);
                wallTemp.transform.position = tran.position + new Vector3(-1.5f,0,0);
            }
            if (heigh == 0 && i == str.Length-1)
            {
                wallTemp = GameObject.Instantiate<GameObject>(wall, map);
                wallTemp.transform.position = tran.position + new Vector3(+1.5f, 0, 0);
            }
            if (heigh == 0 && i == 7)
            {
                groundTemp = GameObject.Instantiate<GameObject>(ground, map);
                groundTemp.transform.position = tran.position + new Vector3(0, -1.7f, 0);
            }
        }
   
    }
    public void CreatLevel(string lin1, string lin2, string lin3, string lin4, string lin5, string lin6, string lin7, string lin8,float levelpoint)
    {
        CreatMapList(lin1, 0f, levelpoint);
        CreatMapList(lin2, 1.7f, levelpoint);
        CreatMapList(lin3, 3.4f, levelpoint);
        CreatMapList(lin4, 5.1f, levelpoint);
        CreatMapList(lin5, 6.8f, levelpoint);
        CreatMapList(lin6, 8.5f, levelpoint);
        CreatMapList(lin7, 10.2f, levelpoint);
        CreatMapList(lin8, 11.9f, levelpoint);

        //camera.transform.position = new Vector3(levelpoint + 11.9f, 5.95f,-10f);
    }
}