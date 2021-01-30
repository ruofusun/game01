using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainPanelControl : MonoBehaviour
{
    public Button btn_Start;
    public Button btn_Close;
    public string sceneName;
    void Update()
    {
        
    }
    public void StartGame()
    {
        SceneManager.LoadScene(sceneName);
    }
    public void CloseGame() 
    {
        Application.Quit();    
    }
}
