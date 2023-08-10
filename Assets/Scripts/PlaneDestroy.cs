using UnityEngine;
using System;

public class PlaneDestroy : MonoBehaviour
{
    [SerializeField] int health;

    public event Action OnPlaneDestroy;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Rock"))
        {
            health--;
            Debug.Log("Plane's health is " + health);
        }

        if (health == 0)
        {
            Destroy(gameObject);

            OnPlaneDestroy?.Invoke();
        }
    }
}
