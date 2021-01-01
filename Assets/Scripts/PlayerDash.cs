using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{

    public Rigidbody2D rigidbody2D;
    private bool _isDashing;
    private float _dashCountdown;
    private Vector3 _dashForce;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (_isDashing)
        {
            Debug.Log(_dashCountdown);
            rigidbody2D.AddForce(_dashForce);
            _dashCountdown -= Time.deltaTime;
            if (_dashCountdown < 0f)
            {
                _isDashing = false;
            }
        }
    }

    public void Dash()
    {
        if (!_isDashing)
        {
            _isDashing = true;
            _dashCountdown = .5f;
            Debug.Log("dashing");
            Vector3 dashForce = new Vector3(50f, 0f, 0f);    
        }
    }
}
