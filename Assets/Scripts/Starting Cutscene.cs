using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class StartingCutscene : MonoBehaviour
{
    [SerializeField] float xPos;
    [SerializeField] float duration;
    [Space(20)]
    [SerializeField] CameraMove cameraToBeMoved;
    [SerializeField] Transform plane;

    void Awake()
    {
        cameraToBeMoved.ToFollow = plane;
        plane.DOMoveX(xPos, duration).SetEase(Ease.OutSine).OnComplete(() => cameraToBeMoved.ChangeToPlayer());
    }
}
