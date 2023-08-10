using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    [SerializeField] Camera mainCam;
    
    float startTime;

    void Update()
    {
        
    }

    IEnumerator Switch() {
        startTime = Time.time;
        yield return new WaitForSeconds(1);
    }
}
