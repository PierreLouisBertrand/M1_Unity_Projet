using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    
    public static ChangeScene instance;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance.gameObject);
        }
        else if (this != instance)
        {
            Destroy(this.gameObject);
        }
    }

    public void goToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    
}
