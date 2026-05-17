using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Sandbox.Task10
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
        private bool _wasGroundedLastFrame;

        public bool IsGrounded { get; private set; }

        public event System.Action OnJumped;
        public event System.Action OnLanded;
        public event System.Action OnPaused;
        public event System.Action OnResumed;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _controls = new PlayerControls();
        }

        private void OnEnable()
        {
            _controls.Gameplay.Enable();

            _controls.Gameplay.Jump.performed += OnJumpInput;
            _controls.Gameplay.Pause.performed += OnPauseInput;
            _controls.UI.Resume.performed += OnResumeInput;
        }

        private void OnDisable()
        {
            _controls.Gameplay.Jump.performed -= OnJumpInput;
            _controls.Gameplay.Pause.performed -= OnPauseInput;
            _controls.UI.Resume.performed -= OnResumeInput;

            _controls.Gameplay.Disable();
            _controls.UI.Disable();
        }

        private void OnJumpInput(InputAction.CallbackContext ctx)
        {
            _jumpQueued = true;
        }

        private void OnPauseInput(InputAction.CallbackContext ctx)
        {
            _controls.Gameplay.Disable();
            _controls.UI.Enable();
            OnPaused?.Invoke();
        }

        private void OnResumeInput(InputAction.CallbackContext ctx)
        {
            _controls.UI.Disable();
            _controls.Gameplay.Enable();
            OnResumed?.Invoke();
        }

        private void FixedUpdate()
        {
            CheckGround();
            ApplyMovement();
            ApplyJump();
            DetectLanding();
            _wasGroundedLastFrame = IsGrounded;
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
                OnJumped?.Invoke();
            }
            _jumpQueued = false;
        }

        private void DetectLanding()
        {
            if (IsGrounded && !_wasGroundedLastFrame)
            {
                OnLanded?.Invoke();
            }
        }

        private void CheckGround()
        {
            RaycastHit2D hit = Physics2D.Raycast(_groundCheckPoint.position, Vector2.down, _groundCheckDistance, _groundLayer);
            IsGrounded = hit.collider != null;
        }
    }
}

