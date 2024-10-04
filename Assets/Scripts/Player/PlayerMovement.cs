using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    private const string HORIZONTAL_AXIS = "Horizontal";
    [SerializeField] private float _playerSpeed = 5f;
    [SerializeField] private float _jumpHeight = 2f;
    [SerializeField] private float _gravityForce = -9.81f;
    [SerializeField] private float _groundedForce = -2f;

    private float _verticalVelocity;
    private CharacterController _controller;

    [SerializeField] private float _rotationSpeed = 180f;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        HandleMovementAndRotation();
        ApplyGravity();
    }

    private void HandleMovementAndRotation()
    {
        Vector2 input = InputManager.Movement;

        Vector3 move = (transform.right * input.x + transform.forward * input.y) * _playerSpeed;

        float rotationInput = Input.GetAxisRaw(HORIZONTAL_AXIS);
        transform.Rotate(Vector3.up, rotationInput * _rotationSpeed * Time.deltaTime);

        move.y = _verticalVelocity;

        _controller.Move(move * Time.deltaTime);
    }

    private void ApplyGravity()
    {

        if (_controller.isGrounded)
        {
            if (_verticalVelocity < 0)
                _verticalVelocity = _groundedForce;

            if (InputManager.JumpWasPressed)
            {
                _verticalVelocity = Mathf.Sqrt(_jumpHeight * -2f * _gravityForce);
            }
        }
        _verticalVelocity += _gravityForce * Time.deltaTime;
    }
}
