using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed;
    public Joystick joystick;
    public Animator animator;
    public GameObject weaponSlot;
    private bool _isMoving; // utilisé pour gérer l'animation de déplacement du personnage
    private bool _isFacingLeft; // pour faire regarder le personnage dans la direction dans laquelle il va

    void Start()
    {
        _isFacingLeft = false; // par défaut, le personnage regarde vers la droite
    }

    // Update is called once per frame
    void Update()
    {
        // Récupération des inputs
        float inputX = joystick.Horizontal;
        float inputY = joystick.Vertical;
        
        if (inputX > 0.0f)
        {
            _isMoving = true;
            _isFacingLeft = false;
        }
        else if (inputX < 0.0f)
        {
            _isMoving = true;
            _isFacingLeft = true; // "true" car du coup le joystick est vers la gauche
        }
        else if (inputY != 0.0f)
        {
            _isMoving = true;
        }
        else 
        {
            _isMoving = false;
        }

        Vector2 movement = new Vector2(
            inputX * moveSpeed,
            inputY * moveSpeed
        );
        
        animator.SetBool("IsMoving", _isMoving);

        GetComponent<Rigidbody2D>().velocity = movement;

        
        Vector3 weaponSlotPosition = weaponSlot.transform.position;
        if (_isFacingLeft)
        {
            weaponSlotPosition.x = transform.position.x - .4f;
        }
        else
        {
            weaponSlotPosition.x = transform.position.x + .4f;
        }
        weaponSlot.GetComponent<Transform>().position = weaponSlotPosition;
        
        GetComponent<SpriteRenderer>().flipX = _isFacingLeft;

        
    }
}
