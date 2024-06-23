using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchFlightModeFlight : MonoBehaviour
{
    [SerializeField] GameObject flightFolder, breakingFolder;
    [SerializeField] Camera mainCamera;

    bool isinBreaking;
    bool insideBox = true;

    void OnSwitch() {
        if (isinBreaking) SwitchToFlight();
        else SwitchToBreaking();
    }

    void SwitchToBreaking() {
        flightFolder.SetActive(false);
        breakingFolder.SetActive(true);
        isinBreaking = true;
    }

    void SwitchToFlight() {
        if (insideBox) {
            flightFolder.SetActive(true);
            breakingFolder.SetActive(false);
            isinBreaking = false;
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
