using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IslandHop : MonoBehaviour
{
    public void IslandSwitch(string islandName) {
        SceneManager.LoadScene(islandName);
    }
}
