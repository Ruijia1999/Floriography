using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FireworkSettingUI : UIBase
{
    Button btn_Start;
    Button btn_Return;
    public override void Init(params object[] args)
    {
        base.Init();
        layer = UILayer.scenePanel;
    }
    public override void OnShowing(params object[] args)
    {
        btn_Start = go_UI.transform.Find("btn_start").GetComponent<Button>();
        btn_Start.onClick.AddListener(StartPlay);
        btn_Return = go_UI.transform.Find("btn_return").GetComponent<Button>();
        btn_Return.onClick.AddListener(Return);
    }
    public override void OnShowed(params object[] args) { }
    public override void Update() { }
    public override void OnClosing(params object[] args) { }
    public override void OnClosed(params object[] args) { }

    void StartPlay()
    {
        Close();
        UIManager.Instance.CloseUI("BackpackUI");
        StartCoroutine(FireworkController.Instance.PlayFirework());
        CameraController.Instance.SwitchTo(CameraController.Instance.fireworkPlayCamera);

    }

    void Return()
    {
        TimeSystemController.Instance.Continue();
        Close();
        PlayerMove.Instance.Enable();
        UIManager.Instance.GetUI<BackpackUI>().EndSettingUpFirework();      
        CameraController.Instance.SwitchTo(CameraController.Instance.mainCamera);
    }
}
