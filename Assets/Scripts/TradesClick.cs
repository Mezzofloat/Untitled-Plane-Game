using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.UI;
using Unity.VisualScripting;

public class TradesClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static event Action<TradesClick> OnTradesClick;

    float fillAmount;

    Image whiteArrow;

    Tweener arrowFill, arrowDefill;

    public void Awake()
    {
        whiteArrow = transform.Find("White Arrow").gameObject.GetComponent<Image>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        arrowDefill?.Kill();
        arrowFill = whiteArrow.DOFillAmount(1, 1).SetEase(Ease.InQuad);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        arrowFill?.Kill();
        if (whiteArrow.fillAmount != 1) { 
            arrowDefill = whiteArrow.DOFillAmount(0, 0.5f).SetEase(Ease.Linear);
        } else {
            OnTradesClick?.Invoke(this);
            arrowDefill = whiteArrow.DOFillAmount(0, 0);
        }
    }
}
