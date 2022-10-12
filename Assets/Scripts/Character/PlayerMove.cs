using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    float f_moveSpeed;

    [SerializeField]
    float f_gravity;


    CharacterController characterController;

    public LayerMask layerMask;

    void Start()
    {
        characterController = gameObject.GetComponent<CharacterController>();
    }
    private void Update()
    {
        
    }
    void FixedUpdate()
    {

        MoveControlBySimpleMove();

    }
    void MoveControlBySimpleMove()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        

        Vector3 direction = new Vector3(horizontal * f_moveSpeed, 0, vertical * f_moveSpeed);
        direction = direction.normalized;
        characterController.Move(new Vector3(0,-f_gravity,0));
        characterController.Move(direction*f_moveSpeed);

        
        
    }
}
