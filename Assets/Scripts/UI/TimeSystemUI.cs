using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSystemUI : UIBase
{
    GameObject go_clockHand;

    public override void Init(params object[] args)
    {
        base.Init(args);
        layer = UILayer.panel;
    }
    public override void OnShowing(params object[] args) {
        go_clockHand = go_UI.transform.Find("img_clock/clockHand").gameObject;
    }
    public override void OnShowed(params object[] args) { }
    public override void Update() { }
    public override void OnClosing(params object[] args) { }
    public override void OnClosed(params object[] args) { }

    public void UpdateClock(TimeSystemInGame timeInGame)
    {
        float rotateAngle = -timeInGame.hour * 30;

        go_clockHand.transform.rotation = Quaternion.Euler(0, 0, rotateAngle);
    }
}
