using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolBox : BagBase
{

    private void Start()
    {
        Init();
    }
    // Start is called before the first frame update
    public void Init()
    {
        base.Init();

        i_gridCount = trs_content.childCount;

        for (int i = 0; i < i_gridCount; i++)
        {
            lst_bagGrids.Add( trs_content.GetChild(i).GetComponent<ToolBoxGrid>());
            trs_content.GetChild(i).GetComponent<ToolBoxGrid>().b_draggable = true;
            trs_content.GetChild(i).GetComponent<ToolBoxGrid>().b_showQuantity = false;
            trs_content.GetChild(i).GetComponent<ToolBoxGrid>().Init();

        }
    }
}
