using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UILayer
{
    panel,
    tip,
    scene,
    scenePanel
}

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    private GameObject go_canvas;

    public Dictionary<string, UIBase> dic_UI;

    //Control the layer of UI
    private Dictionary<UILayer, Transform> dic_layer;

    public void Awake()
    {
        Instance = this;
        InitLayer();
        dic_UI = new Dictionary<string, UIBase>();
        //UIManager.Instance.OpenUI<TimeSystemUI>("UIPrefabs/TimeSystemUI");
        //UIManager.Instance.OpenUI<NPCTipUI>("UIPrefabs/NPCTipUI");
        //UIManager.Instance.OpenUI<BackpackUI>("UIPrefabs/BackpackUI");

    }

    public void Start()
    {
        
    }
    private void InitLayer()
    {
        go_canvas = GameObject.Find("Canvas");
        if (go_canvas == null)
        {
            Debug.LogError("UIManager.InitLayer fail, canvas is null");
        }
        dic_layer = new Dictionary<UILayer, Transform>();
        foreach(UILayer layer in Enum.GetValues(typeof(UILayer))){
            string name = layer.ToString();
            Transform transform = go_canvas.transform.Find(name);
            dic_layer.Add(layer, transform);
        }
    }

    public T GetUI<T>()
    {
        return go_canvas.GetComponent<T>();
    }
    //UI operator
    public void OpenUI<T>(string UIPath, params object[] args) where T : UIBase
    {
        string name = typeof(T).ToString();
        UIBase ui;
        if (dic_UI.ContainsKey(name))
        {
            ui = (UIBase)dic_UI[name];
            ui.OnShowing(args);
            ui.OnShowed(args);
            GetUI<T>().go_UI.SetActive(true);
            return;
        }

        ui = go_canvas.AddComponent<T>();
        ui.Init(args);
        dic_UI.Add(name, ui);

        GameObject skin = Resources.Load<GameObject>(UIPath);
        if (skin == null)
        {
            Debug.LogError("UIManager.OpenUI fail, skin is null, skin path = " + UIPath);
        }

        ui.go_UI = (GameObject)Instantiate(skin);
        Transform skinTrans = ui.go_UI.transform;
        UILayer layer = ui.layer;
        Transform parent = dic_layer[layer];
        skinTrans.SetParent(parent);

        ui.OnShowing(args);
        ui.OnShowed(args);
    }


    public void CloseUI(string name)
    {
        UIBase ui = (UIBase)dic_UI[name];

        if (ui == null)
        {
            return;
        }

        ui.OnClosing();
        ui.go_UI.SetActive(false);
        ui.OnClosed();
        
    }

    public void DestroyUI(string name)
    {
        UIBase ui = (UIBase)dic_UI[name];
        if (ui == null)
        {
            return;
        }

        ui.OnClosing();
        dic_UI.Remove(name);
        ui.OnClosed();
        GameObject.Destroy(ui.go_UI);
        Component.Destroy(ui);
    }

}
