using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTrajectoryPreview : MonoBehaviour
{
    //[SerializeField] GameObject janaPeninsula, splitSpit, misIsles, axertAtoll, fregoIslands, rookcastleArchipelago, istempoIsthmus, otoReef;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void OnHover(GameObject caller) {
        caller.transform.GetChild(1).gameObject.SetActive(!caller.transform.GetChild(1).gameObject.activeSelf);
    }
}
