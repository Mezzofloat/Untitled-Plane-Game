using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchFlightMode : MonoBehaviour
{
    void OnSwitch()
    {
        SceneManager.LoadScene(1 - SceneManager.GetActiveScene().buildIndex);
    }
}
