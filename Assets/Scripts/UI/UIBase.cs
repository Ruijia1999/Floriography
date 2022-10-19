using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIBase : MonoBehaviour
{
    public string str_UIPath;
    public GameObject go_UI;
    public UILayer layer;
    public object[] args;

    public virtual void Init(params object[] args) {
        this.args = args;
    }
    public virtual void OnShowing(params object[] args) { }
    public virtual void OnShowed(params object[] args) { }
    public virtual void Update() { }
    public virtual void OnClosing(params object[] args) { }
    public virtual void OnClosed(params object[] args) { }

    protected virtual void Close()
    {
        string name = this.GetType().ToString();
        UIManager.Instance.CloseUI(name);
    }

    protected virtual void DestroyUI()
    {
        string name = this.GetType().ToString();
        UIManager.Instance.DestroyUI(name);
    }
}
