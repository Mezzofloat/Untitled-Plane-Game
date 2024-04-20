using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTrajectoryPreview : MonoBehaviour
{
    public void OnHover(GameObject caller) {
        GameObject child = caller.transform.GetChild(1).gameObject;
        bool enab = !child.activeSelf;

        caller.transform.GetChild(1).gameObject.SetActive(enab);
    }
}
