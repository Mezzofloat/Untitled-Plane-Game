using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField] float speed = 12f;
    
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.right);
    }
}
