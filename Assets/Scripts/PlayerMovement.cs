using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        

        //Needs Animation
        if (Input.GetButtonDown("Crouch"))
        { crouch = true; }
        else if(Input.GetButtonUp("Crouch"))
        { crouch = false; }

        if (Input.GetButtonDown("Jump"))
        { jump = true;
            //animator.jump = true; 
        }
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
