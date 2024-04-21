using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControlPauseUI : MonoBehaviour
{
    [SerializeField] GameObject pauseScreen;

    PlayerInput pi;

    void Awake() {
        pi = GetComponent<PlayerInput>();
    }

    void OnPause() {
        pi.DeactivateInput();

        pauseScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume() {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);

        pi.ActivateInput();
    }
}
