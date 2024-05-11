using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchFlightModeFlight : MonoBehaviour
{
    [SerializeField] Camera mainCam;
    [SerializeField] float zoomTime;

    void Awake() {
        
    }

    void OnSwitch()
    {
        SwitchToBreaking();
    }

    void SwitchToFlight() {
        mainCam.orthographicSize = 0.01f;
        mainCam.transform.position = transform.position;
        mainCam.DOOrthoSize(5, zoomTime).SetEase(Ease.OutSine);
        mainCam.transform.DOMove(new Vector3(0, 0, -10), zoomTime).OnComplete(() => 
            SceneManager.LoadScene(1 - SceneManager.GetActiveScene().buildIndex)
        );   
    }

    void SwitchToBreaking() {
        mainCam.DOOrthoSize(0.01f, zoomTime).SetEase(Ease.OutSine);
        mainCam.transform.DOMove(transform.position, zoomTime).OnComplete(() =>
            SceneManager.LoadScene(1 - SceneManager.GetActiveScene().buildIndex)
        );
    }
}
