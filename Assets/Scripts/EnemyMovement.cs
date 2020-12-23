using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    private SpriteRenderer _spriteRenderer;
    private GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = player.GetComponent<Transform>().position;
        Vector3 enemyPosition = transform.position;
        playerPosition.z = enemyPosition.z; // puisque le jeu est en 2D, on s'assure que les calculs suivants ne prendront pas en compte la profondeur
        float distance = Vector3.Distance(playerPosition, enemyPosition);
        if (distance < 5f)
        {
            transform.position = Vector3.MoveTowards(enemyPosition, playerPosition, 0.01f);
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
