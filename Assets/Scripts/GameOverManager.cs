using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{

    public Text title, score;
    public Button continueButton;

    void Start()
    {
        if (GameState.instance.PlayerHasLost)
        {
            AudioManager.instance.Play("GameOver");
            continueButton.enabled = false;
            title.text = "Vous avez perdu... (niveau " + GameState.instance.CurrentLevel + ")";
            score.text = "Score : " + GameState.instance.GetScore();
        }
        else if (GameState.instance.CurrentLevel == 3) // le joueur vient de terminer le dernier niveau du jeu
        {
            AudioManager.instance.Play("GameVictory");
            continueButton.enabled = false;
            title.text = "Vous avez terminé le jeu !";
            score.text = "Score : " + GameState.instance.GetScore();
        }
        else // le joueur a terminé le niveau 1 ou 2
        {
            AudioManager.instance.Play("LevelVictory");
            continueButton.enabled = true;
            title.text = "Niveau " + GameState.instance.CurrentLevel + " réussi !";
            score.text = "Score : " + GameState.instance.GetScore();
        }
    }

    public void GoToNextLevel()
    {
        Debug.Log("go to next level (game over manager)");
        GameState.instance.GoToNextLevel();
    }

    public void GoToMainMenu()
    {
        GameState.instance.GoToMainMenu();
    }
}
