using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    
    private Animator _animator; // pour déclancher les animations d'attaque
    private bool _equipped;
    private bool _equippedByPlayer; // true si l'arme est équippée par un joueur, (pour éviter qu'il se blesse en attaquant)
    private BoxCollider2D _weaponBoxCollider2D; // pour activer/désactiver le collider
    private BoxCollider2D _weaponHolderBoxCollider2D; // pour éviter que le porteur de l'arme ne soit touché par le trigger de l'arme
    public float damage = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _weaponBoxCollider2D = GetComponent<BoxCollider2D>();
        _weaponBoxCollider2D.enabled = false;
    }

    public void Attack_Clockwise()
    {
        AudioManager.instance.Play("SwordWoosh");
        _animator.SetTrigger("Attack_Clockwise");
    }
    
    public void Attack_CounterClockwise()
    {
        AudioManager.instance.Play("SwordWoosh");
        _animator.SetTrigger("Attack_CounterClockwise");
    }

    void EnableCollider()
    {
        _weaponBoxCollider2D.enabled = true;
        Debug.Log("Collider activé");
    }

    void DisableCollider()
    {
        _weaponBoxCollider2D.enabled = false;
        Debug.Log("Collider désactivé");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.Equals(_weaponHolderBoxCollider2D)) // si le trigger concerné n'est pas celui du porteur de l'arme
        {
            if (other.CompareTag("Player"))
            {
                other.GetComponent<Player>().TakeDamage();
            }
            else if (other.CompareTag("Enemy"))
            {
                other.GetComponent<Enemy>().TakeDamage(damage);
            }
        }
    }
}
