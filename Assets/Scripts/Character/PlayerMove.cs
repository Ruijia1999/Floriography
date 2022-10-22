using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public static PlayerMove Instance;
    bool b_enabled;

    [SerializeField]
    float f_moveSpeed;

    [SerializeField]
    float f_gravity;


    CharacterController characterController;

    public LayerMask layerMask;

    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
        characterController = gameObject.GetComponent<CharacterController>();
        Enable();
    }
    private void Update()
    {
        
    }
    void FixedUpdate()
    {
        if(b_enabled)
            MoveControlBySimpleMove();

    }
    void MoveControlBySimpleMove()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        

        Vector3 direction = new Vector3(horizontal, 0, vertical);
        direction = direction.normalized;
        direction.z /= Mathf.Sin(20* Mathf.Deg2Rad);
        direction.x /= Mathf.Cos(20 * Mathf.Deg2Rad);
        characterController.Move(new Vector3(0,-f_gravity,0));
        Debug.Log(direction);
        characterController.Move(direction*f_moveSpeed*0.01f);

        
        
    }

    public void Disable()
    {
        b_enabled = false;
    }

    public void Enable()
    {
        b_enabled = true;
    }
    //void OnControllerColliderHit(ControllerColliderHit hit)
    //{

    //    if (hit != null && hit.collider.tag == "NPC")
    //    {
    //        hit.collider.GetComponent<NPCInteraction>().OnPlayerNear();
    //    }

    //}
}
