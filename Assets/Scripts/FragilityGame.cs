using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FragilityGame : MonoBehaviour
{
    [SerializeField] GameObject plane;
    [SerializeField] Transform[] targets;

    bool areWeDoneYet;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Box").Length; i++) {
            targets[i].gameObject.SetActive(true);
        }
    }

    void Update()
    {
        foreach (Transform target in targets) {
            if (!target.gameObject.activeSelf) {
                areWeDoneYet = true;
            } else {
                areWeDoneYet = false;
                break;
            }
        }
        
        if (areWeDoneYet) {
            StartCoroutine(EndBreaking());
        }
    }

    IEnumerator EndBreaking() {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("InFlight");
    }
}
