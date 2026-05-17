using System;
using UnityEngine;

namespace Sandbox.Task08
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 5f;
        [SerializeField] private float _jumpForce = 10f;
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private float _groundCheckDistance = 0.1f;
        [SerializeField] private Transform _groundCheckPoint;

        Rigidbody2D _rb;

        private bool _jumpQueued;
        private float _moveInput;
        private bool _wasGroundedLastFrame;

        public event Action OnJumped;
        public event Action OnLanded;

        public Vector2 CurrentVelocity { get; private set; }
        public bool IsGrounded { get; private set; }

        private void CheckGround()
        {
            RaycastHit2D hit = Physics2D.Raycast(_groundCheckPoint.position, Vector2.down, _groundCheckDistance, _groundLayer);

            IsGrounded = hit.collider != null;
        }
        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            _moveInput = Input.GetAxisRaw("Horizontal");

            if (Input.GetKeyDown(KeyCode.Space)) _jumpQueued = true;
        }

        private void FixedUpdate()
        {
            CheckGround();

            _rb.linearVelocity = new Vector2(_moveInput * _moveSpeed, _rb.linearVelocity.y);

            if (IsGrounded && !_wasGroundedLastFrame)
            {
                OnLanded?.Invoke();
            }

            _wasGroundedLastFrame = IsGrounded;

            if (_jumpQueued && IsGrounded)
            {
                _rb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
                OnJumped?.Invoke();
                _jumpQueued = false;
            }


        }
    }
}
