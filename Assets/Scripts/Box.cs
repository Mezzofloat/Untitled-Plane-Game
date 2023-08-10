using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] MovePlayerBreaking mpb;

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("box collided");
        if (other != null && other.gameObject.tag.Equals("Box")) {
            mpb.collidingBoxes.Add(other.transform);
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other != null && other.gameObject.tag.Equals("Box")) {
            mpb.collidingBoxes.Remove(other.transform);
        }
    }
}
