using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class Clickable3D : MonoBehaviour, IPointerClickHandler
{
    
    public UnityEvent _rightClicked;
    public UnityEvent _leftClicked;

    public void Init(UnityEvent leftClicked, UnityEvent rightClicked)
    {

        _rightClicked = rightClicked;
        _leftClicked = leftClicked;

    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Right)
        {
            Debug.Log(gameObject.name + " is clicked.");
            if (_rightClicked != null)
                _rightClicked.Invoke();
        }else if (eventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log(gameObject.name + " is clicked.");
            if (_leftClicked != null)
                _leftClicked.Invoke();
        }

    }
}
