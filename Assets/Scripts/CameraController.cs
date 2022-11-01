using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController Instance;
    public Camera mainCamera;
    public Camera fireworkPlayCamera;
    public Camera fireworkSetCamera;
    public Camera curCamera;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            curCamera = mainCamera;
        }
        else
        {
            Destroy(this);
        }
    }

    public void SwitchTo(Camera camera)
    {
        curCamera.gameObject.SetActive(false);
        curCamera = camera;
        camera.gameObject.SetActive(true);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
