using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagBase
{
    List<BagGrid> lst_bagGrids;
    Dictionary<string, BagItem> dct_items;
    int gridNumber;


    public BagBase(Transform trs_content)
    {
        lst_bagGrids = new List<BagGrid>();
        dct_items = new Dictionary<string, BagItem>();
        gridNumber = trs_content.childCount;
        for(int i = 0; i<gridNumber; i++)
        {
            lst_bagGrids.Add(new BagGrid( trs_content.GetChild(i)));
        }
    }

    public void AddItem(string s_name, int i_quantity)
    {
        foreach(BagGrid grid in lst_bagGrids)
        {
            if (grid.s_itemName == s_name)
            {
                grid.Add(i_quantity);
                return;
            }
        }

        foreach(BagGrid grid in lst_bagGrids)
        {
            if(grid.s_itemName == "")
            {
                grid.AddItem(s_name, i_quantity);
                return;
            }
        }

        Debug.LogError("Bag is full");
    }

    public void RemoveItem(string s_name, int i_quantity)
    {

    }

}
