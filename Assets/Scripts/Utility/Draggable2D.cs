using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Draggable2D : MonoBehaviour, IDragHandler
{
    public bool b_isDragged;

    public void Update()
    {
        if (b_isDragged)
        {
            transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z);
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z);
    }

}
