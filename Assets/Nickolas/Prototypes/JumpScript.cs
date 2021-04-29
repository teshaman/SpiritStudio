using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScript : MonoBehaviour
{
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    public bool limitJumps;
    public float numberOfJumps = 0.0f;
    public float maxJumps = 1.0f;
    private Vector3 moveDirection = Vector3.zero;
    public CharacterController controller;

    void Update()
    {
        if (numberOfJumps > maxJumps - 1)
        {
            limitJumps = false;
        }

        if (controller.isGrounded && Input.GetButton("Jump"))
        {
            moveDirection.y = jumpSpeed;
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

    void OnCollisionEnter(Collision other)
    {
        limitJumps = true;
        numberOfJumps = 0;
    }

    void OnCollisionExit(Collision other)
    {
        
    }
}