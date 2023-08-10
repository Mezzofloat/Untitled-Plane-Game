using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMove : MonoBehaviour
{
    [SerializeField] float maxSpeed = 10;
    [SerializeField] Animator a;
    [SerializeField] Sprite deadBird;

    [HideInInspector] public Vector3 speed;

    void Start()
    {
        speed = new Vector3(Random.Range(-maxSpeed, -5), 0);
        a.speed = -5f / speed.x;
    }

    void Update()
    {
        transform.Translate(Time.deltaTime * speed, Space.World);

        if (transform.position.x <= -8.89 - transform.localScale.x / 2) {
            Destroy(gameObject);
        }
        if (transform.position.y <= -6) {
            Destroy(gameObject);
        }
    }

    public void Die() {
        a.enabled = GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().sprite = deadBird;
        speed = Vector2.down * 10;
    }
}
