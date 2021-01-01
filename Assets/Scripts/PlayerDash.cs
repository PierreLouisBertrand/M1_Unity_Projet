using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{

    public Rigidbody2D rigidbody2D;
    public float dashForce = 500f;
    public float dashDuration = 0.2f;
    public Joystick joystick;
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
            _dashCountdown = dashDuration;
            Debug.Log("dashing");
            Debug.Log(joystick.Horizontal);
            Debug.Log(joystick.Vertical);
            _dashForce = new Vector3(dashForce * joystick.Horizontal, dashForce * joystick.Vertical, 0f);
            Debug.Log(_dashForce.x);
            Debug.Log(_dashForce.y);
            Debug.Log(_dashForce.z);
        }
    }
}
