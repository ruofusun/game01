using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class EndAniPanelControl : MonoBehaviour
{
    public void ChangeToMainScene() {
        SceneManager.LoadScene("MainPage");  
    }
}
