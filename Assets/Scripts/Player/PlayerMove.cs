using System;
using UnityEngine;

[RequireComponent(typeof(PlayerInput), typeof(Rigidbody2D))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _maxSpeed = 5f;
    [SerializeField] private float _acceleration = 15f;
    [SerializeField] private float _deceleration = 20f;
        
    private Vector2 _moveDirection;

    private PlayerInput _playerInput;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _rigidbody = GetComponent<Rigidbody2D>();

        _playerInput.OnMove += SetMoveDirection;
    }
    
    private void OnDestroy()
    {
        _playerInput.OnMove -= SetMoveDirection;
    }

    private void FixedUpdate()
    {
        ApplyMovement();
    }

    private void ApplyMovement()
    {
        Vector2 targetVelocity = _moveDirection.normalized * _maxSpeed;
        float rate = _moveDirection == Vector2.zero ? _deceleration : _acceleration;
        _rigidbody.velocity = Vector2.MoveTowards(_rigidbody.velocity, targetVelocity, rate * Time.fixedDeltaTime);
    }
    
    private void SetMoveDirection(Vector2 direction)
    {
        _moveDirection = direction;
    }
}