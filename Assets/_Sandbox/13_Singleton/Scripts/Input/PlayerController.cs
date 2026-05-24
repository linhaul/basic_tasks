using UnityEngine;
using UnityEngine.InputSystem;

namespace Sandbox.Task13
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 5f;
        [SerializeField] private float _jumpForce = 10f;
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private float _groundCheckDistance = 0.5f;
        [SerializeField] private Transform _groundCheckPoint;

        private PlayerControls _controls;
        private Rigidbody2D _rb;
        private bool _jumpQueued;

        public bool IsGrounded { get; private set; }

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _controls = new PlayerControls();
        }

        private void OnEnable()
        {
            _controls.Gameplay.Enable();
            _controls.Gameplay.Jump.performed += OnJumpInput;
        }

        private void OnDisable()
        {
            _controls.Gameplay.Jump.performed -= OnJumpInput;
            _controls.Gameplay.Disable();
        }

        private void OnJumpInput(InputAction.CallbackContext ctx)
        {
            _jumpQueued = true;
        }

        private void FixedUpdate()
        {
            CheckGround();
            ApplyMovement();
            ApplyJump();
        }

        private void ApplyMovement()
        {
            Vector2 moveInput = _controls.Gameplay.Move.ReadValue<Vector2>();
            _rb.linearVelocity = new Vector2(moveInput.x * _moveSpeed, _rb.linearVelocity.y);
        }

        private void ApplyJump()
        {
            if (_jumpQueued && IsGrounded)
            {
                _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            }
            _jumpQueued = false;
        }

        private void CheckGround()
        {
            RaycastHit2D hit = Physics2D.Raycast(_groundCheckPoint.position, Vector2.down, _groundCheckDistance, _groundLayer);
            IsGrounded = hit.collider != null;
        }
    }
}

