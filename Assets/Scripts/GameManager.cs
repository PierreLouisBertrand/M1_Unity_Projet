using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    private bool isPaused;

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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pause()
    {
        this.isPaused = true;
        Time.timeScale = 0f;
    }

    public void resume()
    {
        this.isPaused = false;
        Time.timeScale = 1f;
    }
}
