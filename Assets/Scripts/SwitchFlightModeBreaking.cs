using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchFlightModeBreaking : MonoBehaviour
{
    bool insideBox;

    void OnSwitch() {
        if (insideBox) {
            SceneManager.LoadScene("InFlight");
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
