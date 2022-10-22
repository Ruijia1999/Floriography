using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
public class OptionUI : UIBase
{
    UnityAction _yesClicked;
    UnityAction _noClicked;

    Button btn_YES;
    Button btn_NO;
    TextMeshProUGUI txt_tip;

    public override void Init(params object[] args)
    {
        base.Init(args);
        layer = UILayer.scenePanel;
    }

    public override void OnShowing(params object[] args)
    {
        _yesClicked = (UnityAction)args[0];
        _noClicked = (UnityAction)args[1];
        
        btn_YES = go_UI.transform.Find("img_bg/btn_YES").GetComponent<Button>();
        btn_NO = go_UI.transform.Find("img_bg/btn_NO").GetComponent<Button>();
        txt_tip = go_UI.transform.Find("img_bg/tip/text").GetComponent<TextMeshProUGUI>();
        txt_tip.text = (string)args[2];

        btn_YES.onClick.AddListener(Close);
        btn_NO.onClick.AddListener(Close);

        if (_yesClicked != null)
        {
            btn_YES.onClick.AddListener(_yesClicked);
        }
       

        if (_noClicked != null)
        {
            btn_NO.onClick.AddListener(_noClicked);
        }
        
    }

    public override void OnShowed(params object[] args)
    {
        PlayerMove.Instance.Disable();
        TimeSystemController.Instance.Pause();
    }

    public override void Update()
    {

    }

    public override void OnClosing(params object[] args)
    {
        PlayerMove.Instance.Enable();
        TimeSystemController.Instance.Continue();
    }

    public override void OnClosed(params object[] args)
    {

    }

    private void Close()
    {
        UIManager.Instance.DestroyUI("OptionUI");
    }

}
