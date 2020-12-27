using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public float maximumHealth;
    private float _health;
    public Image healthBar;
    
    // Start is called before the first frame update
    void Start()
    {
        _health = maximumHealth;
        healthBar.fillAmount = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        TakeDamage(1f);
    }

    void TakeDamage(float amount)
    {
        _health -= amount;
        UpdateHealthBar();
        if (_health <= 0f)
        {
            Destroy(gameObject);
        }
    }

    void UpdateHealthBar()
    {
        healthBar.fillAmount = _health / maximumHealth;
    }
    
    
}
