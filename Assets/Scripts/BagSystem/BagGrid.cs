using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class BagGrid: MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public string s_itemName;
    protected Image img_item;
    protected Text txt_itemQuantity;

    
    public int i_itemQuantity;

    [HideInInspector]
    public bool b_showQuantity;

    public bool b_draggable;
    public Draggable2D _dragImg;

    Vector3 vec_orgPos;


    public void Init()
    {

        vec_orgPos = transform.position;
        img_item = transform.Find("img_item").GetComponent<Image>();
        txt_itemQuantity = transform.Find("txt_quantity").GetComponent<Text>();

        
    }

    public int AddItem(string s_name, int i_qauntity)
    {
        Sprite tx_Item = Resources.Load<Sprite>("Texture2D/GameItem/" + s_name);
        s_itemName = s_name;
        img_item.sprite = tx_Item;
        i_itemQuantity+= i_qauntity;
        txt_itemQuantity.text = i_itemQuantity.ToString();
        img_item.gameObject.SetActive(true);

        if (b_showQuantity)
        {
            txt_itemQuantity.gameObject.SetActive(true);
        }
        return i_itemQuantity;
    }

    public int RemoveItem(int i_quantity)
    {
        i_itemQuantity -= i_quantity;
        if (i_itemQuantity == 0)
        {
            OnGridClear();
        }
        else
        {
            txt_itemQuantity.text = " " + i_itemQuantity.ToString();
        }
        
        return i_itemQuantity;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (b_draggable&&s_itemName!="" && i_itemQuantity>0)
        {
            
            vec_orgPos = transform.position;
            GameObject img = transform.Find("img_item").gameObject;
            GameObject newImg = Instantiate<GameObject>(img, img.transform.parent);//UIManager.Instance.GetUI<BackpackUI>().go_UI.transform);
            newImg.name = s_itemName;
            _dragImg = (Draggable2D)newImg.AddComponent(typeof(Draggable2D));
            newImg.GetComponent<Draggable2D>().b_isDragged = true;
            RemoveItem(1);
        }

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if(b_draggable)
            OnDragEnd();
    }

    protected virtual void OnDragEnd()
    {

    }

    protected virtual void OnGridClear()
    {
    }
}
