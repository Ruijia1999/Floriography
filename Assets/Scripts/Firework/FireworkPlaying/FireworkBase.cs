using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworkBase: MonoBehaviour
{
    public string s_name;
    public FireworkBase nextFirework;

    private void Start()
    {
        nextFirework = null;
    }
}
