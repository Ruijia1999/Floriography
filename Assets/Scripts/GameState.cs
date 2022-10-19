using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState Instance;
    [HideInInspector]
    public GameObject go_player;
    void Awake()
    {
        go_player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
