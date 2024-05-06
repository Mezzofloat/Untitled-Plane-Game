using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FragilityGame : MonoBehaviour
{
    InstantiateBoxes ib;
    [SerializeField] List<GameObject> targets = new();

    int dones;

    public void ActivateTargets() {
        ib = GetComponent<InstantiateBoxes>();
        for (int i = 0; i < ib.boxNumber; i++) {
            targets[i].SetActive(true);
        }
    }

    public void DetermineWhenEnded() {
        dones++;
        if (dones >= ib.boxNumber) StartCoroutine(nameof(EndBreaking));
    }

    IEnumerator EndBreaking() {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("InFlight");
    }
}
