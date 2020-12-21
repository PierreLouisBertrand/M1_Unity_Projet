using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenteringCameraOnPlayer : MonoBehaviour
{

    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = player.GetComponent<Transform>().position;
        playerPosition.z = -1;
        transform.position = playerPosition;
    }
}
