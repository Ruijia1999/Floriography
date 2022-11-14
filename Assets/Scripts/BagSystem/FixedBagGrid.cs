using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedBagGrid : BagGrid
{
    public void Init()
    {
        base.Init();
    }

    protected override void OnDragEnd()
    {
        //Device
        foreach (DeviceBase device in UIManager.Instance.GetUI<FireworkMakingUI>().dic_Devices.Values)
        {
            if (device.b_isOpen)
            {
                if (device.PutItemIn(_dragImg.name, _dragImg.gameObject))
                {
                    return;
                }
            }
        }

        //Backpack


        //Box
        
        AddItem(_dragImg.name, 1);
        _dragImg.gameObject.SetActive(false);
    }

    protected override void OnGridClear()
    {
        txt_itemQuantity.text = "";

        img_item.gameObject.SetActive(false);
        img_item.sprite = null;
        s_itemName = "";
    }
}
