using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    CharacterController control;
    public float moveSpeed = 5f;
    public float gravity = -9.81f;
    Vector3 velocity;

    void Start()
    {
        control = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Calculate movement direction
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = transform.right * horizontalInput + transform.forward * verticalInput;

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;

        // Move the character controller
        control.Move(moveDirection * moveSpeed * Time.deltaTime + velocity * Time.deltaTime);
        
        // Reset vertical velocity if grounded
        if (control.isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }
    }
}
