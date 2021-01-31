using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreezeMapCreater : MonoBehaviour
{

    string levelE08 = "nnnnnnnnnnnnnnn";
    string levelE07 = "11111100101101n";
    string levelE06 = "011100000000000";
    string levelE05 = "nnnnnnnnnnnnnnn";
    string levelE04 = "nnnnn010n01nnn0";
    string levelE03 = "nnnn0110nnnnnnn";
    string levelE02 = "n1110000nnnnn1";
    string levelE01 = "01001110n00100?";

    string levelD08 = "nnnnnnnnnnnnnnn";
    string levelD07 = "00nnn10101nnn00";
    string levelD06 = "nnnn0n000n1nnnn";
    string levelD05 = "nnn1nn1?1nn0nnn";
    string levelD04 = "nn1nni1i1inn1nn";
    string levelD03 = "1nn0nnnnnnn0nn1";
    string levelD02 = "01nnn00000nnn10";
    string levelD01 = "001000000000100";

    string levelC08 = "nnnnn0nnnn1nnnn";
    string levelC07 = "nnnnn0nnnn0nnnn";
    string levelC06 = "nnnnn0n000100nn";
    string levelC05 = "nnnnnnnnnnnnnnn";
    string levelC04 = "nnn000nnnn10111";
    string levelC03 = "000101n0111n101";
    string levelC02 = "000001n0101n11?";
    string levelC01 = "000001n0101n111";

    string levelB08 = "nnnnnnnnnnnnnnn";
    string levelB07 = "nnnnnnnnnnn1001";
    string levelB06 = "nnnnnnnnnnn020n";
    string levelB05 = "nnnnnnnnnnn01n?";
    string levelB04 = "nnnnnnnnnnn20nn";
    string levelB03 = "nnnnnn102001201";
    string levelB02 = "012001101201200";
    string levelB01 = "102011010100221";

    string levelA08 = "nnnnnnnnnnnnnnn";
    string levelA07 = "nnnnnnnnnnnnnnn";
    string levelA06 = "nnnnnnnn1101nnn";
    string levelA05 = "nnnnnnnnnnnnnnn";
    string levelA04 = "nnnnnnnnnnnnnnn";
    string levelA03 = "nnnnn1nnnnnnnnn";
    string levelA02 = "01210111211010?";
    string levelA01 = "102211111110022";

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
        CreatLevel(levelB01, levelB02, levelB03, levelB04, levelB05, levelB06, levelB07, levelB08, 35f);
        //levelC
        CreatLevel(levelC01, levelC02, levelC03, levelC04, levelC05, levelC06, levelC07, levelC08, 70f);
        //levelD
        CreatLevel(levelD01, levelD02, levelD03, levelD04, levelD05, levelD06, levelD07, levelD08, 105f);
        //levele
        CreatLevel(levelE01, levelE02, levelE03, levelE04, levelE05, levelE06, levelE07, levelE08, 140f);
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