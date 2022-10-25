using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    GameObject go_curDrag;
    GameObject go_curSelect;
    public static MouseController Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            go_curDrag = null;
            go_curSelect = null;
        }
        else
        {
            Destroy(this);
        }
    }
}
