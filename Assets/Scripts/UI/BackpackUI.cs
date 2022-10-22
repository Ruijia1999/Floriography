using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackpackUI : UIBase
{
    FixedBag bag;
    Transform trs_leftPos;
    Transform trs_bottomPos;
    public override void Init(params object[] args)
    {
        base.Init();
        layer = UILayer.scenePanel;
        
    }
    public override void OnShowing(params object[] args) {
        trs_leftPos = go_UI.transform.Find("leftPos");
        trs_bottomPos = go_UI.transform.Find("bottomPos");
        bag = go_UI.transform.Find("Bag").GetComponent<FixedBag>();
        bag.Init(12);
        bag.transform.localPosition = trs_bottomPos.localPosition;
    }
    public override void OnShowed(params object[] args) { }
    public override void Update() { }
    public override void OnClosing(params object[] args) { }
    public override void OnClosed(params object[] args) { }

    public void AddItem(string s_name, int i_quantity)
    {
        bag.AddItem(s_name, i_quantity);
    }

    public void RemoveItem(string s_name, int i_quantity)
    {

    }

    public void StartSettingFirework()
    {
        bag.transform.localPosition = trs_leftPos.localPosition;
        bag.SetSize(2);
    }

    public void EndSettingUpFirework()
    {
        bag.transform.localPosition = trs_bottomPos.localPosition;
        bag.SetSize(0);
    }
}
