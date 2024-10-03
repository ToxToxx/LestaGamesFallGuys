using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _playerSpeed = 5f;               
    [SerializeField] private float _jumpHeight = 2f;          
    [SerializeField] private float _gravityForce = -9.81f;         
    private float _verticalVelocity;        
    private Vector3 _movement;              

    private CharacterController _controller;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        HandleMovement();
        HandleJumping();
    }

    private void HandleMovement()
    {
        Vector2 input = InputManager.Movement;

        Vector3 move = transform.right * input.x + transform.forward * input.y;
        move *= _playerSpeed;


        if (_controller.isGrounded && _verticalVelocity < 0)
        {
            _verticalVelocity = -2f;  
        }

        _movement = move + Vector3.up * _verticalVelocity;

        _controller.Move(_movement * Time.deltaTime);
    }

    private void HandleJumping()
    {
        if (InputManager.JumpWasPressed && _controller.isGrounded)
        {
            _verticalVelocity = Mathf.Sqrt(_jumpHeight * -2f * _gravityForce);
        }
        _verticalVelocity += _gravityForce * Time.deltaTime;
    }
}
