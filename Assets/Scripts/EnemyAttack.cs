using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAttack : MonoBehaviour
{

    public Weapon weapon;
    public float attackDelay; // temps en secondes entre deux attaques successives
    private float _timeFromLastAttack; // variable qui stocke le temps en secondes depuis la dernière attaque
    private EnemyMovement _enemyMovement;
    public Image timeBar;

    // Start is called before the first frame update
    void Start()
    {
        _timeFromLastAttack = attackDelay;
        _enemyMovement = GetComponent<EnemyMovement>();
        timeBar.fillAmount = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        _timeFromLastAttack -= Time.deltaTime;
        if (_timeFromLastAttack <= 0f)
        {
            Attack();
            _timeFromLastAttack = attackDelay + 1f;
        }

        UpdateTimeBar();
    }

    void UpdateTimeBar()
    {
        float fillAmount = _timeFromLastAttack / attackDelay;
        timeBar.fillAmount = fillAmount;
    }

    void Attack()
    {
        if (_enemyMovement.IsFacingRight)
        {
            weapon.Attack_Clockwise();
            Debug.Log("Attaque ! (droite)");
        }
        else
        {
            weapon.Attack_CounterClockwise();
            Debug.Log("Attaque ! (gauche)");
        }
    }
}
