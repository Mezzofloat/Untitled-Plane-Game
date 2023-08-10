using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    [SerializeField] Sprite deadBird;

    void Update()
    {
        if (transform.position.x >= 8.89f + 0.75f / 2f) {
            Destroy(gameObject);           
        }
        if (transform.position.x <= -8.89 - 0.75f / 2f) {
            Destroy(gameObject);
        }    
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Rock")) {
            other.GetComponent<BirdMove>().Die();
            Destroy(gameObject);
        }
    }
}
