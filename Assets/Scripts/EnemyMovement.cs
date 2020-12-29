using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float sightDistance = 3f;
    public float doNotGoFurtherDistance = 1.2f; // pas certain du nom de celle-ci, utilisée pour ne pas trop s'approcher du joueur car il est dangereux
    public float movementSpeed = 3f;
    public Animator animator;
    private SpriteRenderer _spriteRenderer;
    private GameObject _player;
    private Rigidbody2D _enemyRigidbody;
    private bool _playerIsInSight;
    private bool _isChasingPlayer;
    public bool hasRunningAnimation = true;
    
    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _player = GameObject.FindGameObjectWithTag("Player");
        _enemyRigidbody = GetComponent<Rigidbody2D>();
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
            _enemyRigidbody.MovePosition(Vector2.MoveTowards(enemyPosition, playerPosition, Time.deltaTime * movementSpeed));
            
            if (playerPosition.x > enemyPosition.x)
            {
                _spriteRenderer.flipX = false;
            }
            else
            {
                _spriteRenderer.flipX = true;
            }

            if (hasRunningAnimation)
            {
                animator.SetBool("IsMoving", true);    
            }
        }
        else
        {
            _enemyRigidbody.velocity = new Vector2(0f, 0f);
            if (hasRunningAnimation)
            {
                animator.SetBool("IsMoving", false);
            }
        }
    }
}
