using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] Transform player;

    void FixedUpdate()
    {
        transform.position = player.position + new Vector3(0, 0, -10);
    }
}
