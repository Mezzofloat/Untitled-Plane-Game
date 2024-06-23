using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SwitchFlightModeFlight : MonoBehaviour
{
    [SerializeField] GameObject flightFolder, breakingFolder;
    [SerializeField] Transform plane;
    [SerializeField] Camera mainCamera;

    bool isinBreaking;
    bool insideBox = true;

    void OnSwitch() {
        if (isinBreaking) SwitchToFlight();
        else SwitchToBreaking();
    }

    void SwitchToBreaking() {
        mainCamera.DOOrthoSize(0.1f, 0.5f);
        mainCamera.transform.DOMove(plane.position, 0.5f).SetEase(Ease.InOutSine).OnComplete(() => {
            flightFolder.SetActive(false);
            breakingFolder.SetActive(true);
            isinBreaking = true;
            mainCamera.transform.position = new Vector3(0,0,-10);
            mainCamera.orthographicSize = 5;
        });
    }

    void SwitchToFlight() {
        if (insideBox) {
            mainCamera.transform.position = plane.position;
            flightFolder.SetActive(true);
            breakingFolder.SetActive(false);
            isinBreaking = false;
            mainCamera.orthographicSize = 0.1f;
            
            mainCamera.transform.DOMove(new Vector3(0,0,-10), 0.5f).SetEase(Ease.InOutSine);
            mainCamera.DOOrthoSize(5, 0.5f);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            insideBox = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player")) {
            insideBox = false;
        }
    }
}
