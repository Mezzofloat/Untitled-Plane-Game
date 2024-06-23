using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class StartingCutscene : MonoBehaviour
{
    [SerializeField] CameraMove cameraMove;
    [SerializeField] Transform plane, runway;

    void Start() {
        Vector3 endVal = new Vector3(runway.position.x, runway.position.y, -10);
        cameraMove.ChangeToSpline(cameraMove.transform.DOMove(endVal, 2));
        plane.DOMove(runway.position, 2).OnComplete(() => cameraMove.ChangeToPlayer());
    }
}
