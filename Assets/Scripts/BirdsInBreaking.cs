using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdsInBreaking : MonoBehaviour
{
    [SerializeField] Camera mainCam;
    [SerializeField] GameObject plane;
    [SerializeField] GameObject bird;
    [SerializeField] PlaneDestroy pd;

    float probability;

    void Start()
    {
        probability = (plane.GetComponent<BoxCollider2D>().size.y + bird.GetComponent<BoxCollider2D>().size.y) / mainCam.orthographicSize;
        StartCoroutine("SpawnFakeBird");
    }

    IEnumerator SpawnFakeBird()
    {
        while (true) {
            float randomTime = Random.Range(0.9f, 1.6f);
            yield return new WaitForSeconds(randomTime / probability);
            pd.OnPlaneHit();
        }
    }

    void OnEnable() {
        StartCoroutine(nameof(SpawnFakeBird));
    }

    void OnDisable()
    {
        StopCoroutine(nameof(SpawnFakeBird));
    }
}
