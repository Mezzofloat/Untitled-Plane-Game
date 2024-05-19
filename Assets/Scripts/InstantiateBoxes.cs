using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateBoxes : MonoBehaviour
{
    [Range(1,4)] public int boxNumber;
    [SerializeField] List<GameObject> boxes;
    [SerializeField] GameObject plane;

    void Awake()
    {
        float maxX = plane.GetComponent<BoxCollider2D>().size.x * plane.transform.localScale.x / 2 - boxes[0].transform.localScale.x;
        float maxY = plane.GetComponent<BoxCollider2D>().size.y * plane.transform.localScale.y / 2 - boxes[0].transform.localScale.y;

        for (int i = 0; i < boxNumber; i++) {
            float x = Random.Range(-maxX, maxX);
            float y = Random.Range(-maxY, maxY);
            float t = Random.Range(-90, 90);

            boxes[i].transform.SetPositionAndRotation(new Vector3(x,y,0), Quaternion.Euler(new Vector3(0,0,t)));
            boxes[i].SetActive(true);

            //Instantiate(box, new Vector3(x,y,-0.3f), Quaternion.Euler(0, 0, t));
        }
    }
}
