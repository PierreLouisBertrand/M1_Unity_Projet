using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
        
        if (other.CompareTag("Player"))
        {
            AudioManager.instance.Play("HoleFall");
            // Partie terminée, le joueur vient de mourir en tombant dans le trou
            GameState.instance.PlayerDeath();
        }
    }
}
