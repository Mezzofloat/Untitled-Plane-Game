using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine.InputSystem;

public class CompleteFlight : MonoBehaviour
{
    [SerializeField] Transform plane;
    
    public static int timeInSeconds { private get; set; } = 15;
    public static string destination { private get; set; } = "JanaPeninsula";

    void Start() => Invoke("End", 5);

    void End()
    {
        plane.gameObject.GetComponent<PlayerInput>().enabled = false;
        plane.DORotate(new Vector3(0,0,-30), 1.5f).SetEase(Ease.InQuad);
        plane.DOMoveX(10, 1.5f).SetEase(Ease.InQuad);
        plane.DOMoveY(plane.position.y - 7, 1.5f).SetEase(Ease.InQuad).OnComplete(() => SceneManager.LoadScene(destination));
    }
}
