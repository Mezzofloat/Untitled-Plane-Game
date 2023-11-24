using System.Collections;
using System.Collections.Generic;
using UnityEditor.ProjectWindowCallback;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteFlight : MonoBehaviour
{
    public static int timeInSeconds { private get; set; } = 15;
    public static string destination { private get; set; } = "JanaPeninsula";

    void Start() => Invoke("End", 5);
    void End() => SceneManager.LoadScene(destination);
}
