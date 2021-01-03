using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    
    public Animator transition;
    public float transitionTime = 1f;

    private void Start()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameState>().setChangeScene(this);
    }

    public void goToLevel1()
    {
        StartCoroutine(LoadLevel("Level 1 - Undeads"));
    }

    IEnumerator LoadLevel(string levelName)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelName);
    }

    public void goToLevel2()
    {
        StartCoroutine(LoadLevel("Level 2 - Orcs"));
    }

    public void goToLevel3()
    {
        StartCoroutine(LoadLevel("Level 3 - Demons"));
    }

    public void goToMainMenu()
    {
        StartCoroutine(LoadLevel("MainMenu"));
    }

    public void goToGameOver()
    {
        StartCoroutine(LoadLevel("GameOver"));
    }
}
