using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{

    public Door[] doorsAround; // liste des portes qui sont reliées à la salle
    public GameObject enemies; // doit pointer vers le gameObject qui a comme enfants les ennemis de la salle
    public Door exitDoor;
    private bool _hasPlayerEntered;
    public bool isFinalBossRoom;

    // Update is called once per frame
    void Update()
    {
        if (!_hasPlayerEntered) // si le joueur n'est pas encore entré dans la salle,
                                // on en surveille pas la complétion
                                // (fait de tuer tous les ennemis dans la salle)
        {
            return;
        }
        if (enemies.transform.childCount == 0) // s'il n'y a plus d'ennemis dans la salle
        {
            OnRoomFinished();
        }
    }

    void OnPlayerEntry()
    {
        AudioManager.instance.Play("RoomStart");

        foreach (var door in doorsAround) 
        {
            door.Close();
        }

        for (int i = 0; i < enemies.transform.childCount; i++)
        {
            // Pour chaque ennemi, on active le suivi du joueur (déplacement vers le joueur)
            enemies.transform.GetChild(i).GetComponent<EnemyMovement>().IsChasingPlayer = true;
        }
    }

    void OnRoomFinished()
    {
        Debug.Log("Le joueur vient de finir la salle");
        
        AudioManager.instance.Play("RoomEnd");
        
        if (!isFinalBossRoom)
        {
            exitDoor.Open(); // on ouvre la porte de sortie, pour que le joueur puisse accéder à la salle suivante
        }
        else // c'est la dernière salle du niveau, il faut donc féliciter le joueur et lui proposer d'aller au niveau suivant
        {
            GameState.instance.LevelFinished();
        }

        this.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_hasPlayerEntered)
        {
            Debug.Log("Le joueur rentre dans le collider d'entrée, mais on s'en fout car il est déjà dans la salle");
            return; // si le joueur est déjà entré dans la salle et qu'il revient
                    // dans la zone d'entrée, ce n'est pas important
        }
        if (other.transform.CompareTag("Player")) // le joueur est entré dans la salle
        {
            Debug.Log("Le joueur est entré dans la salle");
            _hasPlayerEntered = true;
            OnPlayerEntry();
        }
    }
}
