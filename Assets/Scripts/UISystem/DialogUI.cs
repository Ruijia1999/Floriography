using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DialogUI : UIBase
{
    TextMeshProUGUI txt_NPCName;
    TextMeshProUGUI txt_dialogContent;


    public override void Init(params object[] args)
    {
        base.Init(args);
        layer = UILayer.scenePanel;
        
      
    }
    public override void OnShowing(params object[] args)
    {

        txt_NPCName = go_UI.transform.Find("img_bg/name/text").GetComponent<TextMeshProUGUI>();
        txt_dialogContent = go_UI.transform.Find("img_bg/content/text").GetComponent<TextMeshProUGUI>();
        txt_NPCName.text = args[0].ToString();
        txt_NPCName.gameObject.SetActive(true);
        txt_dialogContent.text = args[1].ToString();
        txt_dialogContent.gameObject.SetActive(true);
    }
    public override void OnShowed(params object[] args) { 
        DialogSystemController.Instance.DialogComplete += Close;
    }
    public override void Update() {
       
    }
    public override void OnClosing(params object[] args) { 
    }
    public override void OnClosed(params object[] args) {
        DialogSystemController.Instance.DialogComplete -= Close;
    }

    public void ContinueDialog(string content)
    {
        txt_dialogContent.text = content;
        
    }

    
}
