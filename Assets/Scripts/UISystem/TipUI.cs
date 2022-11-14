using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
public class TipUI : UIBase
{

    Button btn_return;
    TextMeshProUGUI txt_tip;
    Image img_tip;

    public override void Init(params object[] args)
    {
        base.Init(args);
        layer = UILayer.scenePanel;
    }

    public override void OnShowing(params object[] args)
    {
       
        btn_return = go_UI.transform.Find("img_bg").GetComponent<Button>();
        txt_tip = go_UI.transform.Find("img_bg/tip/text").GetComponent<TextMeshProUGUI>();
        txt_tip.text = (string)args[0];
        img_tip = go_UI.transform.Find("img_bg/img").GetComponent<Image>();
        img_tip.sprite = Resources.Load<Sprite>((string)args[1]);
        btn_return.onClick.AddListener(DestroyUI);
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

}
