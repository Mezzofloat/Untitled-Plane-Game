using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovePlayerBreaking : MonoBehaviour
{
    #region Variables
    [SerializeField] float speed = 7f;

    Vector3 input;
    Vector3 prevPosition;
    Rigidbody2D rbody;
    Vector3 xInput, yInput;
    public List<Transform> collidingBoxes;
    bool shouldMoveX = true, shouldMoveY = true;
    #endregion

    void Awake()
    {
        rbody = GetComponent<Rigidbody2D>();
        collidingBoxes = new List<Transform>();
    }

    void OnMove(InputValue value)
    {
        input = new Vector3(value.Get<Vector2>().x, value.Get<Vector2>().y);
        
    }

    void FixedUpdate()
    {
        xInput = new Vector3(input.x, 0);
        yInput = new Vector3(0, input.y);
        for (int i = 0; i < collidingBoxes.Count; i++) {
            if (!CanMove(collidingBoxes.ToArray())[0,i]) {
                shouldMoveX = false;
                break;
            }
        }
        for (int i = 0; i < collidingBoxes.Count; i++) {
            if (!CanMove(collidingBoxes.ToArray())[1,i]) {
                shouldMoveY = false;
                break;
            }
        }
        
        if (!Physics2D.Raycast(transform.position + new Vector3(-0.5f * transform.localScale.x, 0), yInput, 0.5f) && 
            !Physics2D.Raycast(transform.position + new Vector3(0.5f * transform.localScale.x, 0), yInput, 0.5f) &&
            shouldMoveY) {
            transform.Translate(yInput * speed * Time.deltaTime);
        }
        if (!Physics2D.Raycast(transform.position + new Vector3(0, -0.5f * transform.localScale.y), xInput, 0.5f) && 
            !Physics2D.Raycast(transform.position + new Vector3(0, 0.5f * transform.localScale.y), xInput, 0.5f) &&
            shouldMoveX) {
            transform.Translate(xInput * speed * Time.deltaTime);
        }

        for (int i = 0; i < collidingBoxes.Count; i++) {
            if (CanMove(collidingBoxes.ToArray())[0,i]) {
                shouldMoveX = true;
                break;
            }
        }
        for (int i = 0; i < collidingBoxes.Count; i++) {
            if (CanMove(collidingBoxes.ToArray())[1,i]) {
                shouldMoveY = true;
                break;
            }
        }

        if (collidingBoxes.Count == 0) {
            shouldMoveX = true;
            shouldMoveY = true;
        }
    }

    bool[] CanMove(Transform box) {
        bool[] xy = new bool[2] {!Physics2D.Raycast(box.position, xInput, 0.5f), !Physics2D.Raycast(box.position, yInput, 0.5f)};
        return xy;
    }
    bool[,] CanMove(Transform[] boxes) {
        bool[,] xys = new bool[2,boxes.Length];
        for (int i = 0; i < boxes.Length; i++) {
            xys[0,i] = !Physics2D.Raycast(boxes[i].position, xInput, 0.5f);
            xys[1,i] = !Physics2D.Raycast(boxes[i].position, yInput, 0.5f);
        }
        return xys;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        collidingBoxes.Add(other.gameObject.transform);
    }

    void OnCollisionExit2D(Collision2D other)
    {
        collidingBoxes.Remove(other.gameObject.transform);
    }
}
