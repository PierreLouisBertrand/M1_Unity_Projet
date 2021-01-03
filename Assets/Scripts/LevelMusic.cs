using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMusic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.Stop("MainMenuMusic");
        AudioManager.instance.Play("Cave");
        AudioManager.instance.Play("LevelStart");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
