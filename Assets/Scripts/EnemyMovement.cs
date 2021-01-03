using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float doNotGoFurtherDistance = 1.2f; // pas certain du nom de celle-ci, utilisée pour ne pas trop s'approcher du joueur car il est dangereux
    public float movementSpeed = 3f;
    public Animator animator;
    private SpriteRenderer _spriteRenderer;
    private GameObject _player;
    private Rigidbody2D _enemyRigidbody;
    private bool _isChasingPlayer; // par défaut, les ennemis ignorent le joueur
    public bool hasRunningAnimation = true;
    public GameObject weaponSlot;
    private float _weaponSlotOffset;
    private bool _isFacingRight;
    
    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _player = GameObject.FindGameObjectWithTag("Player");
        _enemyRigidbody = GetComponent<Rigidbody2D>();
        _weaponSlotOffset = weaponSlot.transform.position.x - transform.position.x;
        _isFacingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isChasingPlayer) // quand l'ennemi est "activé"
        {
            Vector3 playerPosition = _player.transform.position;
            Vector3 enemyPosition = transform.position;
            playerPosition.z = enemyPosition.z; // puisque le jeu est en 2D, on s'assure que les calculs de distance ne prennent pas en compte le Z
            float distance = Vector3.Distance(playerPosition, enemyPosition);
        
            if (distance > doNotGoFurtherDistance) // si le joueur n'est pas assez loin
            {
                _enemyRigidbody.MovePosition(Vector2.MoveTowards(enemyPosition, playerPosition, Time.deltaTime * movementSpeed));

                Vector3 weaponSlotPosition = weaponSlot.transform.position;
            
                if (playerPosition.x > enemyPosition.x)
                {
                    _spriteRenderer.flipX = false;
                    _isFacingRight = true;
                    weaponSlotPosition.x = transform.position.x + _weaponSlotOffset;
                }
                else
                {
                    _spriteRenderer.flipX = true;
                    _isFacingRight = false;
                    weaponSlotPosition.x = transform.position.x - _weaponSlotOffset;
                }

                weaponSlot.GetComponent<Transform>().position = weaponSlotPosition;

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

    public bool IsFacingRight => _isFacingRight;

    public bool IsChasingPlayer
    {
        set => _isChasingPlayer = value;
    }
}
