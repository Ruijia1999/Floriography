using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ToolBoxGrid : BagGrid, IPointerDownHandler, IPointerUpHandler
{
    
    public void Init()
    {
        base.Init();
    }

    protected override void OnDragEnd()
    {
        //Device
        foreach(DeviceBase device in UIManager.Instance.GetUI<FireworkMakingUI>().dic_Devices.Values)
        {
            if (device.b_isOpen)
            {
                if (device.PutItemIn(s_itemName, _dragImg.gameObject))
                {
                    return;
                }
            }
        }
        //Backpack


        //Box
        _dragImg.gameObject.SetActive(false);
        AddItem(s_itemName, 1);
    }

    protected override void OnGridClear()
    {
        txt_itemQuantity.text = "0";
    }
}

