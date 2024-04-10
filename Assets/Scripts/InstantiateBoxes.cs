using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateBoxes : MonoBehaviour
{
    [SerializeField] [Range(1,4)] int boxNumber;
    [SerializeField] GameObject box, plane;

    void Awake()
    {
        float maxX = plane.GetComponent<BoxCollider2D>().size.x * plane.transform.localScale.x / 2 - box.transform.localScale.x;
        float maxY = plane.GetComponent<BoxCollider2D>().size.y * plane.transform.localScale.y / 2 - box.transform.localScale.y;

        for (int i = 0; i < boxNumber; i++) {
            float x = Random.Range(-maxX,maxX);
            float y = Random.Range(-maxY, maxY);

            Instantiate(box, new Vector3(x,y,-0.3f), Quaternion.identity);
        }
    }
}
