using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FireworkBoard:MonoBehaviour
{

    public void OpenTip()
    {

        object[] args = {(UnityAction)StartSettingUp,null, "Ready to start setting up the fireworks?" };
        UIManager.Instance.OpenUI<OptionUI>("UIPrefabs/OptionUI", args);
    }
    void StartSettingUp()
    {
        TimeSystemController.Instance.Pause();
        PlayerMove.Instance.Disable();
        UIManager.Instance.OpenUI<FireworkSettingUI>("UIPrefabs/FireworkSettingUI");
        UIManager.Instance.GetUI<BackpackUI>().StartSettingFirework();
        CameraController.Instance.curCamera = CameraController.Instance.fireworkSetCamera;
        CameraController.Instance.fireworkSetCamera.gameObject.SetActive(true);
        CameraController.Instance.mainCamera.gameObject.SetActive(false);

    }

}
