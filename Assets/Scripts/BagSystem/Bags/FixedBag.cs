using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FixedBag : BagBase
{
    public int i_columCount; //colum count is fixed;
    GridLayoutGroup layout; //The bag layout
            
      
    public void SetSize(int columCount)
    {
        i_columCount = columCount;
        layout.constraintCount = i_columCount;
    }
    public void Init(bool showQuantity, bool draggable, int gridCount, int columCount = 0)
    {

        base.Init();
        GameObject go_bagGrid = Resources.Load<GameObject>("BagGrid");
        i_gridCount = gridCount;
        for (int i = 0; i < i_gridCount; i++)
        {
            GameObject go = Instantiate<GameObject>(go_bagGrid, trs_content);
            go.GetComponent<BagGrid>().b_showQuantity = showQuantity;
            go.GetComponent<BagGrid>().b_draggable = draggable;
            lst_bagGrids.Add(go.GetComponent<FixedBagGrid>());
            go.GetComponent<BagGrid>().Init();
        }

        layout = transform.Find("content").GetComponent<GridLayoutGroup>();
        if (columCount == 0)
        {
            i_columCount = gridCount;
        }
        layout.constraintCount = i_columCount;
    }

}
