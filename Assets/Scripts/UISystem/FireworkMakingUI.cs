using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireworkMakingUI : UIBase
{
    Button btn_return;
    public override void Init(params object[] args)
    {
        base.Init();
        layer = UILayer.scenePanel;
        
    }
    public override void OnShowing(params object[] args)
    {
        btn_return = go_UI.transform.Find("btn_return").GetComponent<Button>();
        btn_return.onClick.AddListener(ExitLab);
    }
    public override void OnShowed(params object[] args) { }
    public override void Update() { }
    public override void OnClosing(params object[] args) { }
    public override void OnClosed(params object[] args) { }

    void ExitLab()
    {
        UIManager.Instance.CloseUI("FireworkMakingUI");
    }

}
