using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState instance;
    private ChangeScene _changeScene;
    private bool _level1finished, _level2finished, _level3finished, _playerHasLost;
    private int _playerHitsCountLevel1, _playerHitsCountLevel2, _playerHitsCountLevel3;
    private int _currentLevel = 1;

    public void setChangeScene(ChangeScene changeScene)
    {
        _changeScene = changeScene;
    }
    
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

    private void Reset()
    {
        _level1finished = false;
        _level2finished = false;
        _level3finished = false;
        _playerHitsCountLevel1 = 0;
        _playerHitsCountLevel2 = 0;
        _playerHitsCountLevel3 = 0;
        _currentLevel = 1;
    }

    public void PlayerHit()
    {
        if (_level2finished) // le joueur est dans le niveau 3
        {
            _playerHitsCountLevel3 += 1;
        }
        else if (_level1finished) // le joueur est dans le niveau 2
        {
            _playerHitsCountLevel2 += 1;
        }
        else
        {
            _playerHitsCountLevel1 += 1;
        }
    }

    public void LevelFinished()
    {
        switch (_currentLevel)
        {
            case 1:
                _level1finished = true;
                Debug.Log("niveau 1 terminé");
                break;
            case 2:
                _level2finished = true;
                Debug.Log("niveau 2 terminé");
                break;
            default:
                _level3finished = true;
                Debug.Log("niveau 3 terminé");
                break;
        }
        _changeScene.goToGameOver();
    }

    public void PlayerDeath()
    {
        _playerHasLost = true;
        _changeScene.goToGameOver();
    }

    public void GoToNextLevel()
    {
        Debug.Log("go to next level");
        
        _currentLevel++;

        if (_currentLevel == 2)
        {
            Debug.Log("-> goto level 2");
            _changeScene.goToLevel2();
        }
        else if (_currentLevel == 3)
        {
            Debug.Log("--> goto level 3");
            _changeScene.goToLevel3();
        }
    }

    public void GoToMainMenu()
    {
        Reset();
        _changeScene.goToMainMenu();
    }

    public int GetScore()
    {
        int score = 0;
        if (_level1finished)
        {
            score += 6 - _playerHitsCountLevel1;
        }
        
        if (_level2finished)
        {
            score += 2 * (6 - _playerHitsCountLevel2);
        }
        
        if (_level3finished)
        {
            score += 3 * (6 - _playerHitsCountLevel3);
        }

        return score;
    }

    public bool PlayerHasLost => _playerHasLost;

    public int PlayerHitsCountLevel1 => _playerHitsCountLevel1;
    
    public int PlayerHitsCountLevel2 => _playerHitsCountLevel2;
    
    public int PlayerHitsCountLevel3 => _playerHitsCountLevel3;

    public int CurrentLevel => _currentLevel;
}
