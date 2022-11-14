using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabEntry:MonoBehaviour
{
    public void EnterLab()
    {
        UIManager.Instance.OpenUI<FireworkMakingUI>("UIPrefabs/FireworkMakingUI");
    }
}
