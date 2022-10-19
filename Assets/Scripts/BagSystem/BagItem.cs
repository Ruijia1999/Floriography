using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagItem
{
    public string s_itemName;
    public int i_itemQuantity;

    public int Add()
    {
        i_itemQuantity++;
        return i_itemQuantity;
    }
}
