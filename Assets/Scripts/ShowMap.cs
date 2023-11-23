using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowMap : MonoBehaviour
{
    [SerializeField] GameObject map;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnMap() {
        map.SetActive(!map.activeSelf);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
