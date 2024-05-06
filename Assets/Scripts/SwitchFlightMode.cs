using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;

public class SwitchFlightMode : MonoBehaviour
{
    [SerializeField] UnityEvent inFlight, inBreaking;
    [SerializeField] Camera mainCam;
    [SerializeField] float zoomInTime;
    [SerializeField] Transform plane;

    bool goingToBreaking;

    void OnSwitch()
    {
        goingToBreaking = !goingToBreaking;

        if (goingToBreaking) {
            SwitchToBreaking();
        }
        else {
            inFlight.Invoke();
            SwitchToFlight();
        }

        /*
        zoom in to the plane's backside
        * disable the inflight
        * enable the inbreaking
        * slow down the bird generator
        */
    }

    void SwitchToFlight() {
        mainCam.orthographicSize = 0.01f;
        mainCam.transform.position = plane.position;
        mainCam.DOOrthoSize(5, zoomInTime).SetEase(Ease.OutSine);
        mainCam.transform.DOMove(new Vector3(0, 0, -10), zoomInTime);   
        mainCam.backgroundColor = new Color(0x30 / 255f, 0x34 / 255f, 0x3f / 255f);
    }

    void SwitchToBreaking() {
        mainCam.DOOrthoSize(0.01f, zoomInTime).SetEase(Ease.OutSine);
        mainCam.transform.DOMove(plane.position, zoomInTime).OnComplete(() => {
            inBreaking.Invoke();
            mainCam.orthographicSize = 5;
            mainCam.transform.position = new Vector3(0, 0, -10);
            mainCam.backgroundColor = new Color(0xfc / 255f, 0xb2 / 255f, 0x66 / 255f);
        });
    }
}
