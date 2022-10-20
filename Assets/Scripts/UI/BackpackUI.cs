using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackpackUI : UIBase
{
    BagBase backpackContent;
    
    public override void Init(params object[] args)
    {
        base.Init();
        layer = UILayer.scene;
        backpackContent = null;
        
    }
    public override void OnShowing(params object[] args) {
        if (backpackContent == null)
        {
            backpackContent = new BagBase(go_UI.transform.Find("content"));
        }
        
    }
    public override void OnShowed(params object[] args) { }
    public override void Update() { }
    public override void OnClosing(params object[] args) { }
    public override void OnClosed(params object[] args) { }

    public void AddItem(string s_name, int i_quantity)
    {
        backpackContent.AddItem(s_name, i_quantity);
    }

    public void RemoveItem(string s_name, int i_quantity)
    {

    }
}
