using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public void goToMainMenu()
    {
        SceneManager.LoadScene("01 - MainMenu");
    }

    public void goToGame()
    {
        SceneManager.LoadScene("New Scene");
    }
    
}
