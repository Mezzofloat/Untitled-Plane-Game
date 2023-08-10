using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdInstantiate : MonoBehaviour
{
    [SerializeField] GameObject bird;

    float yRandom;
    float tRandom;
    Vector3 instantiatePos;
    PlaneDestroy planeDestroy;

    void Start()
    {    
        planeDestroy = FindObjectOfType<PlaneDestroy>();
        planeDestroy.OnPlaneDestroy += OnGameOver;
    }

    IEnumerator Throw() {
        while (true) {
            yRandom = Random.Range(-4.4f, 4.4f);
            tRandom = Random.Range(-0.1f,0.6f);
            instantiatePos = new Vector3(8.89f + bird.transform.localScale.x, yRandom, 0);
            Instantiate(bird, instantiatePos, Quaternion.identity);
            yield return new WaitForSeconds(1 + tRandom);
        }
    }

    void OnGameOver() {
        StopCoroutine(nameof(Throw));
    }

    void OnEnable() {
        StartCoroutine(nameof(Throw));
    }

    void OnDisable()
    {
        StopCoroutine(nameof(Throw));
    }
}
