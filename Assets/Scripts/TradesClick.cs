using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TradesClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    public static event Action<TradesClick> OnTradesClick;

    public void OnPointerClick(PointerEventData eventData)
    {
        OnTradesClick?.Invoke(this);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        transform.localScale *= 0.9f;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.localScale /= 0.9f;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
