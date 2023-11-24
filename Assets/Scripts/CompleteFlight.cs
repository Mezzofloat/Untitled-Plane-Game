using System.Collections;
using System.Collections.Generic;
using UnityEditor.ProjectWindowCallback;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteFlight : MonoBehaviour
{
    public static int timeInSeconds { private get; set; }
    public static string destination { private get; set; }

    void Start() => Invoke("End", timeInSeconds);
    void End() => SceneManager.LoadScene(destination);
}
