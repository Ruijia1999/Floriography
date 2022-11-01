using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagBase: MonoBehaviour
{
    public List<BagGrid> lst_bagGrids;
    public Dictionary<string, BagItem> dct_items;
    GameObject go_bagGrid;
    Transform trs_content;
    public int i_gridCount;

    public void Init(int gridCount)
    {
        go_bagGrid = Resources.Load<GameObject>("BagGrid");
        lst_bagGrids = new List<BagGrid>();
        dct_items = new Dictionary<string, BagItem>();
        trs_content = transform.Find("content");
        i_gridCount = gridCount;
        for (int i = 0; i < i_gridCount; i++)
        {
            GameObject go = Instantiate<GameObject>(go_bagGrid, trs_content);
            lst_bagGrids.Add(go.GetComponent<BagGrid>());
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
