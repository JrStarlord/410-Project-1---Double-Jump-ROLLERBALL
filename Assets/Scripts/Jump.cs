using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Jump : MonoBehaviour
{
    private InputActions _input;
    private Rigidbody rb;
    //private bool _jumped = false;
    private int jumpCount = 0;
    private bool canJump = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _input = new InputActions();
        _input.Player.Enable();
        _input.Player.Jump.performed += Jump_performed;
    }

    private void Jump_performed(InputAction.CallbackContext context)
    {
        if (context.performed && (canJump == true))
        {
            jumpCount += 1;
            rb.AddForce(Vector3.up * 8f, ForceMode.Impulse);
        }
        if (jumpCount > 1)
        {
            canJump = false;
        }

    }
    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            canJump = true;
            jumpCount = 0;
        }
    }
}
