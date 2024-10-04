using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _playerSpeed = 5f;               
    [SerializeField] private float _jumpHeight = 2f;          
    [SerializeField] private float _gravityForce = -9.81f;
    [SerializeField] private float _groundedForce = -2f;

    private float _verticalVelocity;        
    private Vector3 _movement;              

    private CharacterController _controller;

    [SerializeField] private float _rotationSpeed = 180;
    private Vector3 _rotationVector;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        HandleMovement();
        HandleJumping();
        HandleRotation();
    }

    private void HandleMovement()
    {
        Vector2 input = InputManager.Movement;

        Vector3 move = transform.right * input.x + transform.forward * input.y;
        move *= _playerSpeed;

        if (_controller.isGrounded && _verticalVelocity < 0)
        {
            _verticalVelocity = _groundedForce;  
        }

        _movement = move + Vector3.up * _verticalVelocity;
        
        _controller.Move(_movement * Time.deltaTime);
    }

    private void HandleRotation()
    {
        _rotationVector = new Vector3(0, Input.GetAxisRaw("Horizontal") * _rotationSpeed * Time.deltaTime, 0);
        transform.Rotate(_rotationVector);
    }
    private void HandleJumping()
    {
        if (InputManager.JumpWasPressed && _controller.isGrounded)
        {
            _verticalVelocity = Mathf.Sqrt(_jumpHeight * _groundedForce * _gravityForce);
        }
        _verticalVelocity += _gravityForce * Time.deltaTime;
    }
}
