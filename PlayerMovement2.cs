using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    public CharacterController2D controller;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;
   
    void Update()
    {
         horizontalMove = Input.GetAxisRaw("Horizontal")* runSpeed;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }
        
        
    }
    private void FixedUpdate()
    {
        controller.Move(horizontalMove* Time.deltaTime, false, jump);
        jump = false;
    }
}
