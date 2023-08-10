using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShouldSwitch : MonoBehaviour
{
    [SerializeField] GameObject shouldSwitch;

    float randomTime;

    // Start is called before the first frame update
    void Awake()
    {
        randomTime = Random.Range(10f,20f);
        
        Invoke("EnableOnSwitch", randomTime);
    }

    void EnableOnSwitch() {
        shouldSwitch.SetActive(true);
    }
}
