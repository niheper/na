using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float gravity = 9.8f;
    public float jumpForce;

    private float _fallVelocity = 0;

    private CharacterController _characterController;

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

   void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded) 
            _fallVelocity = -jumpForce;
    }

    void FixedUpdate()
    {
        _fallVelocity += gravity * Time.fixedDeltaTime;
        _characterController.Move(Vector3.down * _fallVelocity * Time.fixedDeltaTime);
    }
}
