using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject GameOverCanvas;
    [SerializeField] Image youCrashed;

    PlaneDestroy planeDestroy;

    void Awake()
    {
        planeDestroy = FindObjectOfType<PlaneDestroy>();
        planeDestroy.OnPlaneDestroy += OnGameOver;
    }

    void OnGameOver() {
        GameOverCanvas.SetActive(true);
        StartCoroutine(nameof(Flash));
        StartCoroutine(nameof(Reset));
    }

    IEnumerator Flash() {
        youCrashed.color = Color.red;
        yield return new WaitForSeconds(0.2f);

        float time = 0;
        while (time <= 1) {
            time += Time.deltaTime * 2;
            youCrashed.color = Color.Lerp(Color.red, Color.white, time);
            yield return null;
        }
    }

    IEnumerator Reset() {
        yield return new WaitForSeconds(1.75f);
        SceneManager.LoadScene("InFlight");
    }
}
