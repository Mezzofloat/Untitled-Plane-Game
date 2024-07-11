using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdInstantiate : MonoBehaviour
{
    [SerializeField] GameObject bird;
    [SerializeField] PlaneDestroy pd;

    float yRandom;
    float tRandom;
    Vector3 instantiatePos;

    void Start()
    {
        pd.OnPlaneDestroy += OnGameOver;
    }

    IEnumerator Throw() {
        while (true) {
            yRandom = Random.Range(-4.4f, 4.4f);
            tRandom = Random.Range(0.9f,1.6f);
            instantiatePos = new Vector3(8.89f + bird.transform.localScale.x, yRandom, 0);
            Instantiate(bird, instantiatePos, Quaternion.identity, transform);
            yield return new WaitForSeconds(tRandom);
        }
    }

    void OnGameOver() {
        StopCoroutine(nameof(Throw));
    }

    void OnEnable() {
        StartCoroutine(nameof(Throw));

        foreach(Transform bird in transform) {
            bird.position = new Vector3(Random.Range(-5f * 16/9, 5f * 16/9), Random.Range(-5f, 5f), 0);
        }
    }

    void OnDisable() {
        StopCoroutine(nameof(Throw));
    }
}
