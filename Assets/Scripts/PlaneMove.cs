using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlaneMove : MonoBehaviour
{
    [SerializeField] float speed = 5f;

    Vector3 move;
    Animator planeAnimator;

    void Awake()
    {
        planeAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        transform.Translate(move * speed * Time.deltaTime);

        if (transform.position.y >= 4.4) {
            transform.position = new Vector3(transform.position.x, 4.4f, 0);
        }
        if (transform.position.y <= -4.4) {
            transform.position = new Vector3(transform.position.x, -4.4f, 0);
        }
    }

    void OnMove(InputValue value) {
        move = new Vector3(0, value.Get<float>(), 0);

        planeAnimator.SetFloat("Y", move.y);
    }
}