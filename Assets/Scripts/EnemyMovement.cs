﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float sightDistance = 3f;
    public float doNotGoFurtherDistance = 1.2f; // pas certain du nom de celle-ci, utilisée pour ne pas trop s'approcher du joueur car il est dangereux
    private SpriteRenderer _spriteRenderer;
    private GameObject _player;
    private bool _playerIsInSight;
    private bool _isChasingPlayer;
    
    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = _player.transform.position;
        Vector3 enemyPosition = transform.position;
        playerPosition.z = enemyPosition.z; // puisque le jeu est en 2D, on s'assure que les calculs de distance ne prennent pas en compte le Z
        float distance = Vector3.Distance(playerPosition, enemyPosition);
        if (distance < sightDistance && distance > doNotGoFurtherDistance) // si l'ennemi est proche du joueur, mais pas trop
        {
            transform.position = Vector3.MoveTowards(enemyPosition, playerPosition, Time.deltaTime * 10f);
            if (playerPosition.x > enemyPosition.x)
            {
                _spriteRenderer.flipX = true;
            }
            else
            {
                _spriteRenderer.flipX = false;
            }
        }
    }
}
