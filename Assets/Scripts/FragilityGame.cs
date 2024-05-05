using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FragilityGame : MonoBehaviour
{
    [SerializeField] InstantiateBoxes ib;
    [SerializeField] List<GameObject> targets = new();

    int dones;

    void Start() {
        for (int i = 0; i < ib.boxNumber; i++) {
            targets[i].SetActive(true);
        }
    }

    public void FindWhenEnded() {
        dones++;
        if (dones >= ib.boxNumber) StartCoroutine(nameof(EndBreaking));
    }

    IEnumerator EndBreaking() {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("InFlight");
    }
}
