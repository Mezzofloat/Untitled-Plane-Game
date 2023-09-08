using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer.Internal;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform ToFollow;

    [SerializeField] Transform player;

    void FixedUpdate()
    {
        transform.position = ToFollow.position + new Vector3(0, 0, -10);
    }

    public void ChangeToPlayer() {
        ToFollow = player;
    }
}
