using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FireworkBagGrid : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool b_isIn;
    public Draggable2D _dragImg;

    public void OnPointerDown(PointerEventData eventData)
    {
        b_isIn = true;
        GameObject img = transform.Find("img_item").gameObject;

        GameObject newImg = Instantiate<GameObject>(img, img.transform.parent);//UIManager.Instance.GetUI<BackpackUI>().go_UI.transform);
        _dragImg = (Draggable2D)newImg.AddComponent(typeof(Draggable2D));
        newImg.GetComponent<Draggable2D>().b_isDragged = true;
    }
    
    public void OnPointerUp(PointerEventData eventData)
    {
        if (b_isIn)
        {
            _dragImg.b_isDragged = false;
            _dragImg.gameObject.SetActive(false);
            FireworkController.Instance.AddFirework(gameObject.GetComponent<BagGrid>().s_itemName);

        }
        else
        {
            _dragImg.gameObject.SetActive(false);
        }
        
        
    }

}
