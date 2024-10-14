using UnityEngine;

public class Movement : MonoBehaviour
{

    public MovementData movementData;
    public Animator animator;
    public Rigidbody2D rb;

    private void Start()
    {
        movementData.speed = movementData.maxSpeed;
    }

    // TODO: create OnMove, OnDash delegates and events to allow modularity

    void FixedUpdate()
    {
        Move();
        ChangeAnimationDirection();
    }


    private void Move()
    {
        rb.linearVelocity = new Vector2(movementData.direction.x, movementData.direction.y) * movementData.speed;

    }


    private void ChangeAnimationDirection()
    {
        // change to move animations if moving
        if (movementData.direction != Vector2.zero)
        {
            animator.SetBool("isMoving", true);

            animator.SetFloat("horizontal", movementData.direction.x);
            animator.SetFloat("vertical", movementData.direction.y);
        }

        // return to idle animations if not moving
        if (movementData.direction == Vector2.zero)
        {
            animator.SetBool("isMoving", false);
        }


    }
}