using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform Player;

    void Update()
    {
        if (Player != null)
        {
            Vector3 position = transform.position;
            position.x = Player.position.x;
            position.y = Player.position.y+1;
            transform.position = position;
        }
    }
}