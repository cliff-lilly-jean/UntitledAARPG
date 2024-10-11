using System;
using UnityEngine;

public class Move : MonoBehaviour
{
    public MovementData movementData;
    public Animator animator;
    public Rigidbody2D rb;

    private GameControls _controls;
    private int _facingDirection = 1; // Default facing direction ins right


    private void Awake()
    {
        _controls = new GameControls();
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movementData.speed = movementData.maxSpeed;

        _controls.Player.Move.performed += _ => GetMoveDirection();
        _controls.Player.Move.canceled += _ => ResetMoveDirection();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateMoveDirection();
    }

    private void OnEnable()
    {
        _controls.Enable();
    }

    private void OnDisable()
    {
        _controls.Disable();
    }

    private void GetMoveDirection()
    {
        movementData.direction = _controls.Player.Move.ReadValue<Vector2>();
    }

    private void UpdateMoveDirection()
    {
        rb.linearVelocity = new Vector2(movementData.direction.x, movementData.direction.y) * movementData.speed;

        CheckAnimationDirection();

    }

    private void ResetMoveDirection()
    {
        movementData.direction = Vector2.zero;
    }

    private void CheckAnimationDirection()
    {
        var horizontalMovement = movementData.direction.x;
        var verticalMovement = movementData.direction.y;

        // Makes sure negative values are converted to positive ones. For use in the animator state machine
        animator.SetFloat("horizontal", Math.Abs(horizontalMovement));
        animator.SetFloat("vertical", Math.Abs(verticalMovement));

        if (horizontalMovement > 0 && transform.localScale.x < 0 ||
        horizontalMovement < 0 && transform.localScale.x > 0)
        {
            Flip();
        }
    }

    private void Flip()
    {
        _facingDirection *= -1; // Make the facing direction the opposite of what it was
        transform.localScale = new Vector3(_facingDirection, transform.localScale.y, transform.localScale.z);
    }
}
