using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenteringCameraOnPlayer : MonoBehaviour
{

    public GameObject player;
    private Vector3 _playerPosition;
    private bool _isCenteringEnabled = true;

    // Update is called once per frame
    void Update()
    {
        if (_isCenteringEnabled)
        {
            _playerPosition = player.GetComponent<Transform>().position;
            transform.position = new Vector3(_playerPosition.x, _playerPosition.y, -10f);   
        }
    }

    public void enableCentering()
    {
        _isCenteringEnabled = true;
    }

    public void disableCentering()
    {
        _isCenteringEnabled = false;
    }
}
