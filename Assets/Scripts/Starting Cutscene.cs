using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class StartingCutscene : MonoBehaviour
{
    [SerializeField] CameraMove cameraMove;
    [SerializeField] Transform plane;

    // Start is called before the first frame update
    void Start()
    {
        cameraMove.ToFollow = plane;
        plane.DOMoveX(-7.13f, 4).SetEase(Ease.OutSine).OnComplete(() => cameraMove.ChangeToPlayer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
