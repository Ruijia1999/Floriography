using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTipUI : UIBase
{
    GameObject go_exclamationMark;
    GameObject go_tip;
    // Start is called before the first frame update
    void Start()
    {
        go_tip = go_UI.transform.Find("Tip").gameObject;
        go_exclamationMark = Resources.Load<GameObject>("UIPrefabs/NPCTipUI/exclamationMark");
    }

    public void ShowTip(Transform trs_tipPos)
    {
        go_tip.SetActive(true);
    }

    public void HideTip()
    {
        go_tip.SetActive(false);
    }
    public GameObject ShowNPCExclamationMark(Transform trs_NPC)
    {
        //ShowTip(trs_NPC);
        Vector3 screenPos = Camera.main.WorldToScreenPoint(trs_NPC.position + new Vector3(0, 2, 0)) ;
        GameObject go = Instantiate<GameObject>(go_exclamationMark, screenPos, Quaternion.identity, go_UI.transform);
        go.GetComponent<ObjectFollowingUI>().trs_followingObject = trs_NPC;
        go.GetComponent<ObjectFollowingUI>().vec_offset = new Vector3(0, 2, 0);
        go.GetComponent<ObjectFollowingUI>().b_isFollowing = true;
        return go;
    }

    public void HideNPCExclamationMark(GameObject go_NPCexclamationMark)
    {
        go_NPCexclamationMark.SetActive(false);
        //HideTip();
    }




}
