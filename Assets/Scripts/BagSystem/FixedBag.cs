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
    public void Init(int gridCount, int columCount = 0)
    {
        base.Init(gridCount);
        layout = transform.Find("content").GetComponent<GridLayoutGroup>();
        if (columCount == 0)
        {
            i_columCount = gridCount;
        }
        layout.constraintCount = i_columCount;
    }

}
