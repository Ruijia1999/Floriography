using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public struct TimeSystemInGame
{
    public float hour;
    public int day;
}

public class TimeSystemController : MonoBehaviour
{
    TimeSystemInGame timeInGame;
    bool b_isRunning;

    [SerializeField]
    float f_minPerDay;
    [SerializeField]
    float f_initialTime;

    float f_lightSpeed;
    float f_timeSpeed;

    GameObject go_mainLight;
    

    // Start is called before the first frame update
    void Start()
    {
        b_isRunning = true;
        UIManager.Instance.OpenUI<TimeSystemUI>("UIPrefabs/TimeSystemUI");
        DontDestroyOnLoad(this);
        timeInGame.hour = f_initialTime;
        go_mainLight = GameObject.Find("MainLight");
        go_mainLight.transform.rotation = Quaternion.Euler(0, -135, 0);
        float rotateAngle = (timeInGame.hour-6) * 30;
        go_mainLight.transform.Rotate(Vector3.right, rotateAngle);

        f_lightSpeed = 360 / f_minPerDay / 60 / 50;
        f_timeSpeed = 12 / f_minPerDay / 60 / 50;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (b_isRunning)
        {
            //Time in game
            timeInGame.hour += f_timeSpeed;
            if (timeInGame.hour >= 12)
            {
                timeInGame.hour %= 12;
                timeInGame.day++;
            }

            //Light
            go_mainLight.transform.Rotate(Vector3.right, f_lightSpeed);
            UpdateLight();
            //Time UI
            UpdateClock();

        }
       
        
    }
    private void UpdateLight()
    {
        if(go_mainLight.GetComponent<Light>().intensity < 0)
        {
            go_mainLight.GetComponent<Light>().intensity = 0;
        }
        if (go_mainLight.GetComponent<Light>().intensity > 1)
        {
            go_mainLight.GetComponent<Light>().intensity = 1;
        }

        go_mainLight.GetComponent<Light>().intensity = 1- Mathf.Abs(timeInGame.hour - 9) / 3;
    }
    private void UpdateClock()
    {
        UIManager.Instance.GetUI<TimeSystemUI>().UpdateClock(timeInGame);
    }
}
