using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting.FullSerializer.Internal;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    Transform toFollow;
    Tween cameraPath;
    bool isOnSpline;

    [SerializeField] Transform player;

    void FixedUpdate()
    {
        if (isOnSpline) return;

        transform.position = toFollow.position + 10 * Vector3.back;
    }

    public void ChangeToPlayer() {
        toFollow = player;
        isOnSpline = false;
    }

    public void ChangeToSpline(Tween spline) {
        cameraPath = spline;
        isOnSpline = true;
    }
}
