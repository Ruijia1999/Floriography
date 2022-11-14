using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagBase: MonoBehaviour
{
    [HideInInspector]
    public List<BagGrid> lst_bagGrids;

    protected Transform trs_content;
    public int i_gridCount;

    public void Init()
    {
        
        lst_bagGrids = new List<BagGrid>();
        trs_content = transform.Find("content");

        
    }

    public bool AddItem(string s_name, int i_quantity)
    {
        foreach(BagGrid grid in lst_bagGrids)
        {
            if (grid.s_itemName == s_name)
            {
                grid.AddItem(s_name, i_quantity);
                return true;
            }
        }

        foreach(BagGrid grid in lst_bagGrids)
        {
            if(grid.s_itemName == "")
            {
                grid.AddItem(s_name, i_quantity);
                return true;
            }
        }

        return false;
    }

    public void RemoveItem(string s_name, int i_quantity)
    {

    }

}
