using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{

    public GameObject weaponSlot;
    private bool _hasWeapon;
    public GameObject weaponAssigned;
    private Weapon _weapon;
    private bool _isFacingRight;
    
    // Start is called before the first frame update
    void Start()
    {
        _hasWeapon = true;
        _weapon = weaponAssigned.GetComponent<Weapon>();
    }

    /**
     * Méthode qui va assigner une arme au joueur (autrement dit, méthode qui permet au joueur de ramasser une arme
     * Si le joueur a déjà une arme, il va la faire tomber là où il se situe
     */
    public void AssingWeapon(GameObject weapon)
    {
        if (_hasWeapon)
        {
            DropWeapon();
        }

    }

    /**
     * Méthode utilisée pour que le joueur lâche l'arme qu'il a en main (s'il en a une)
     */
    public void DropWeapon()
    {
        Debug.Log("DropWeapon");
        if (!_hasWeapon)
        {
            return;
        }
        Vector3 parentPosition = weaponAssigned.transform.parent.position;
        weaponAssigned.transform.parent = null;
        weaponAssigned.transform.position = parentPosition;
        _hasWeapon = false;
        weaponAssigned = null;
    }

    /**
     * Méthode qui permet de savoir si le joueur a une arme en main
     * Permet donc de savoir s'il peut attaquer (pour activer/désactiver le bouton d'attaque sur l'écran)
     */
    public bool hasWeapon()
    {
        return _hasWeapon;
    }

    public void setIsFacingRight(bool isFacingRight)
    {
        _isFacingRight = isFacingRight;
    }

    public void Attack()
    {
        if (_isFacingRight)
        {
            _weapon.Attack_Clockwise();
        }
        else
        {
            _weapon.Attack_CounterClockwise();
        }
    }
}
