using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BagGrid: MonoBehaviour
{
    public string s_itemName;
    public int i_itemQuantity;
    Image img_item;
    Text txt_itemQuantity;
   
    void Start ()
    {
        
        s_itemName = "";
        i_itemQuantity = 0;
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
        txt_itemQuantity.gameObject.SetActive(true);
        return i_itemQuantity;
    }

    public int Add(int i_qauntity)
    {
        i_itemQuantity+=i_qauntity;
        txt_itemQuantity.text = " "+i_itemQuantity.ToString();
        return i_itemQuantity;
    }

    public int RemoveItem(int i_qauntity)
    {
        i_itemQuantity -= i_itemQuantity;
        return i_itemQuantity;
    }
    
    
}
