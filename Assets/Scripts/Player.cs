using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int maximumHealth = 6;
    private int _health;
    public Image firstHearth, secondHearth, thirdHearth;
    public Sprite fullHearth, halfHearth, emptyHearth;
    
    // Start is called before the first frame update
    void Start()
    {
        _health = maximumHealth;
        firstHearth.sprite = fullHearth;
        secondHearth.sprite = fullHearth;
        thirdHearth.sprite = fullHearth;
        
    }

    public void TakeDamage()
    {
        _health -= 1;
        switch (_health)
        {
            case 5:
                thirdHearth.sprite = halfHearth;
                break;
            case 4:
                thirdHearth.sprite = emptyHearth;
                break;
            case 3:
                secondHearth.sprite = halfHearth;
                break;
            case 2:
                secondHearth.sprite = emptyHearth;
                break;
            case 1:
                firstHearth.sprite = halfHearth;
                break;
            case 0:
                firstHearth.sprite = emptyHearth;
                break;
        }

        if (_health == 0)
        {
            // le joueur est éliminé. fin de parcours
        }
    }

    void GainHealth()
    {
        if (_health < maximumHealth)
        {
            _health += 1;
            switch (_health)
            {
                case 1:
                    firstHearth.sprite = halfHearth;
                    break;
                case 2:
                    firstHearth.sprite = fullHearth;
                    break;
                case 3:
                    secondHearth.sprite = halfHearth;
                    break;
                case 4:
                    secondHearth.sprite = fullHearth;
                    break;
                case 5:
                    thirdHearth.sprite = halfHearth;
                    break;
                case 6:
                    thirdHearth.sprite = fullHearth;
                    break;
            }
        }
    }
}
