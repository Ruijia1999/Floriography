using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    GameObject go_exclamationMark;
    public string s_name;
    bool b_isInteractable;
    string s_dialogID;
    void Start()
    {
        DialogSystemController.Instance.DialogComplete += OnDialogComplete;
        s_dialogID = "RedFirework";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (b_isInteractable)
            {
                if(s_dialogID!="")
                    DialogSystemController.Instance.StartDialog(s_dialogID, s_name);
            }
        }
    }

    public void OnPlayerNear()
    {
        b_isInteractable = true;
        if (s_dialogID != "")
        {
            ShowExclamationMark();
        }
        
    }
    public void OnPlayerAway()
    {
        b_isInteractable = false;
        if (s_dialogID != "")
        {
            HideExclamationMark();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        { 
            OnPlayerNear();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            
            OnPlayerAway();
        }
    }
    private void ShowExclamationMark()
    {
        go_exclamationMark = UIManager.Instance.GetUI<NPCTipUI>().ShowNPCExclamationMark(this.transform);
    }
    private void HideExclamationMark()
    {
        UIManager.Instance.GetUI<NPCTipUI>().HideNPCExclamationMark(go_exclamationMark);
    }

    public void OnDialogComplete()
    {
        s_dialogID = "";
        HideExclamationMark();
        DialogSystemController.Instance.DialogComplete -= OnDialogComplete;
    }
}
