using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class PlaneDestroy : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] GameObject heartPrefab;
    [SerializeField] Transform heartsParent;

    public event Action OnPlaneDestroy;
    List<GameObject> hearts;
    float x = 0;

    void Awake()
    {
        hearts = new List<GameObject>();

        while (hearts.Count < health) {
            var h = Instantiate(heartPrefab, heartsParent);
            h.transform.position += new Vector3(x, 0);
            x -= 75;
            hearts.Add(h);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Rock"))
        {
            OnPlaneHit();
        }

        if (health == 0)
        {
            Invoke("DelayDestroy", 1);

            GetComponent<PlayerInput>().DeactivateInput();
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    void DelayDestroy() {
        Destroy(gameObject);
        OnPlaneDestroy?.Invoke();
    }

    public void OnPlaneHit() {
        health--;
        hearts[^1].GetComponent<Animator>().SetTrigger("Explode");
        hearts.RemoveAt(hearts.Count - 1);
    }
}
