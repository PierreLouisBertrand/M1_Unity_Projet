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
    private bool _isFinished;
    private BoxCollider2D _entryCollider;

    // Update is called once per frame
    void Update()
    {
        if (!_isFinished)
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
    }

    void OnPlayerEntry()
    {
        foreach (var door in doorsAround) 
        {
            door.Close();
        }
    }

    void OnRoomFinished()
    {
        Debug.Log("Le joueur vient de finir la salle");
        exitDoor.Open(); // on ouvre la porte de sortie, pour que le joueur puisse accéder à la salle suivante
        _isFinished = true;
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
