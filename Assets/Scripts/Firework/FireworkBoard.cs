using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//Player use right button to click the board to start setting up firework
public class FireworkBoard : MonoBehaviour
{
    Clickable3D _clickableCpt;
    void Start()
    {
        _clickableCpt = gameObject.GetComponent<Clickable3D>();
        _clickableCpt.Init(null, OpenTip);
    }

    void Update()
    {
        
    }

    void OpenTip()
    {

        object[] args = {(UnityAction)StartSettingUp,null, "Ready to start setting up the fireworks?" };
        UIManager.Instance.OpenUI<OptionUI>("UIPrefabs/OptionUI", args);
    }
    void StartSettingUp()
    {
        TimeSystemController.Instance.Pause();
        PlayerMove.Instance.Disable();

        UIManager.Instance.GetUI<BackpackUI>().StartSettingFirework();
        GameObject.Find("Firework").transform.Find("FireworkSetCamera").gameObject.SetActive(true);
        Camera.main.gameObject.SetActive(false);
        
    }

}
