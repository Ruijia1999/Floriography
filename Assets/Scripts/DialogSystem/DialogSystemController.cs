using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogSystemController : MonoBehaviour
{
    public static DialogSystemController Instance;

    public delegate void OnDialogCompleted();
    public OnDialogCompleted DialogComplete;
    Dialog curDialog;
    
    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        DialogComplete = OnDialogComplete;
    }

    void OnDialogComplete()
    {
        curDialog = null;
        UIManager.Instance.OpenUI<BackpackUI>("UIPrefabs/BackpackUI");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (curDialog == null)
            {
                return;
            }
            if (curDialog.curNode != null)
            {
                ContinueDialog();
            }
            else
            {
                DialogComplete();
            }
        }
    }

    public void StartDialog(string ID, string NPCName)
    {
        Dialog dialog = new Dialog("RedFirework","NPC1");
        curDialog = dialog;
        object[] args = { (object)NPCName, (object)dialog.curNode.lst_lines[curDialog.curNode.i_curLine++] };
        UIManager.Instance.OpenUI<DialogUI>("UIPrefabs/DialogUI",args);
        UIManager.Instance.CloseUI("BackpackUI");
    }

    public void ContinueDialog()
    {
        UIManager.Instance.GetUI<DialogUI>().ContinueDialog(curDialog.curNode.lst_lines[curDialog.curNode.i_curLine++]);
        if (curDialog.curNode.i_curLine == curDialog.curNode.lst_lines.Count)
        {
            curDialog.curNode = null;
        }
    }

}
