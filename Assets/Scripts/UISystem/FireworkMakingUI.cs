using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireworkMakingUI : UIBase
{
    Button btn_return;
    Button btn_basic;
    Button btn_firework;
    GameObject go_basic;
    GameObject go_firework;

    [HideInInspector]
    public Dictionary<string, DeviceBase> dic_Devices;

    [HideInInspector]
    public Dictionary<string, ToolBox> dic_Boxes;


    public override void Init(params object[] args)
    {
        base.Init();
        layer = UILayer.scenePanel;
        
    }
    public override void OnShowing(params object[] args)
    {
        
        btn_return = go_UI.transform.Find("btn_return").GetComponent<Button>();
        btn_return.onClick.AddListener(ExitLab);

        btn_basic = go_UI.transform.Find("Materials/Boxes/btn_basic").GetComponent<Button>();
        btn_basic.onClick.AddListener(OpenBasic);
        btn_firework = go_UI.transform.Find("Materials/Boxes/btn_firework").GetComponent<Button>();
        btn_firework.onClick.AddListener(OpenFirework);

        go_basic = go_UI.transform.Find("Materials/Basic").gameObject;
        go_firework = go_UI.transform.Find("Materials/Firework").gameObject;

        Transform devices = go_UI.transform.Find("Devices").transform;
        int deviceCount = devices.childCount;
        dic_Devices = new Dictionary<string, DeviceBase>();
        for (int i = 0; i < deviceCount; i++)
        {
            DeviceBase device = devices.GetChild(i).GetComponent<DeviceBase>();
            dic_Devices.Add(device.str_name, device);
        }

        Transform boxes = go_UI.transform.Find("Materials").transform;
        int boxesCount = boxes.childCount;
        dic_Boxes = new Dictionary<string, ToolBox>();
        for (int i = 0; i < boxesCount; i++)
        {
            ToolBox box = boxes.GetChild(i).GetComponent<ToolBox>();
            if(box!=null)
            dic_Boxes.Add(box.name, box);
        }
    }
    public override void OnShowed(params object[] args) { }
    public override void Update() { }
    public override void OnClosing(params object[] args) { }
    public override void OnClosed(params object[] args) { }

    void OpenBasic()
    {
        go_basic.SetActive(true);
        go_firework.SetActive(false);
    }

    void OpenFirework()
    {
        go_basic.SetActive(false);
        go_firework.SetActive(true);
    }
    void ExitLab()
    {
        UIManager.Instance.CloseUI("FireworkMakingUI");
    }

    public void AddMaterial(string itemNmae, int itemQuantity)
    {
        foreach(var box in dic_Boxes.Values)
        {
            if(box.AddItem(itemNmae, itemQuantity))
            {
                return;
            }
        }
    }
}
