using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] float speed = 7f;
    [SerializeField] Animator anim;

    Vector3 input;
    Vector3 prevPosition;
    Rigidbody2D rbody;

    Vector3 xInput, yInput;

    void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    void OnMove(InputValue value)
    {
        input = new Vector3(value.Get<Vector2>().x, value.Get<Vector2>().y);
        
        if (input.x != 0 || input.y != 0) {
            anim.SetFloat("X", input.x);
            anim.SetFloat("Y", input.y);
            anim.SetBool("IsWalking", true);
        } else {
            anim.SetBool("IsWalking", false);
        }
    }

    void FixedUpdate()
    {
        xInput = new Vector3(input.x, 0);
        yInput = new Vector3(0, input.y);

        prevPosition = transform.position;
        if (!Physics2D.Raycast(transform.position + new Vector3(-0.5f * transform.localScale.x, 0), yInput, 1.3f) && 
            !Physics2D.Raycast(transform.position + new Vector3(0.5f * transform.localScale.x, 0), yInput, 1.3f)) {
            transform.Translate(yInput * speed * Time.deltaTime);
        }
        if (!Physics2D.Raycast(transform.position + new Vector3(0, -0.5f * transform.localScale.y), xInput, 1.3f) && 
            !Physics2D.Raycast(transform.position + new Vector3(0, 0.5f * transform.localScale.y), xInput, 1.3f)) {
            transform.Translate(xInput * speed * Time.deltaTime);
        }
    }
}
