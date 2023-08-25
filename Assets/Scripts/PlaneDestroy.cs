using UnityEngine;
using System;
using System.Collections.Generic;

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
            health--;
            hearts[^1].GetComponent<Animator>().SetTrigger("Explode");
        }

        if (health == 0)
        {
            Destroy(gameObject);

            OnPlaneDestroy?.Invoke();
        }
    }
}
