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
        
    }

    public void TakeDamage(float amount)
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
        float fillAmount = _health / maximumHealth;
        healthBar.fillAmount = fillAmount;
        healthBar.color = Color.Lerp(Color.red, Color.green, fillAmount);
    }
    
    
}
