using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowMap : MonoBehaviour
{
    [SerializeField] GameObject map;
    [SerializeField] Transform plane, player;

    [SerializeField] List<Sprite> animationSprites = new();
    [SerializeField] float waitTime, delayedWaitTime;

    bool isOpening;

    void OnInteract() {
        if ((plane.position - player.position).sqrMagnitude < 3 && !map.activeSelf) {
            map.SetActive(true);
            OpenClose();
        } else if (map.activeSelf) {
            OpenClose();
        }
    }

    void OpenClose() {
        isOpening = !isOpening;
        StartCoroutine("Animate");
    }

    IEnumerator Animate() {
        WaitForSeconds waiting = new WaitForSeconds(waitTime);

        foreach (Transform child in map.transform) {
            child.gameObject.SetActive(false);

            child.GetChild(1).gameObject.SetActive(false);
        }

        if (isOpening) {
            for (int i = 0; i < animationSprites.Count; i++) {
                if (i == 3) {
                    yield return new WaitForSeconds(delayedWaitTime);
                }

                map.GetComponent<Image>().sprite = animationSprites[i];
                yield return waiting;
            }
        } else {
            for (int i = animationSprites.Count - 1; i > 0; i--) {
                if (i == 4) {
                    yield return new WaitForSeconds(delayedWaitTime);
                }

                map.GetComponent<Image>().sprite = animationSprites[i];
                yield return waiting;
            }
            map.SetActive(false);
        }

        foreach (Transform child in map.transform) {
            child.gameObject.SetActive(true);
        }
    }
}
