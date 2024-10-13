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
        // CheckAnimationDirection();
    }


    private void Move()
    {
        rb.linearVelocity = new Vector2(movementData.direction.x, movementData.direction.y) * movementData.speed;

        animator.SetFloat("horizontal", movementData.direction.x);
        animator.SetFloat("vertical", movementData.direction.y);

    }

    // private void CheckAnimationDirection()
    // {

    //     // if (movementData.direction.x > 0 && transform.localScale.x < 0 ||
    //     // movementData.direction.x < 0 && transform.localScale.x > 0)
    //     // {
    //     //     Flip();
    //     // }


    //     // Makes sure negative values are converted to positive ones. For use in the animator state machine
    //     animator.SetFloat("horizontal", Math.Abs(movementData.direction.x));
    //     animator.SetFloat("vertical", Math.Abs(movementData.direction.y));


    // }

    // private void Flip()
    // {
    //     // Make the facing direction the opposite of what it was
    //     // _facingDirection *= -1;

    //     if (rb.linearVelocityX > 0)
    //     {
    //         transform.localScale = Vector3.one;
    //     }

    //     if (rb.linearVelocityX < 0)
    //     {
    //         transform.localScale = new Vector3(-1f, transform.localScale.y, transform.localScale.z);
    //     }
    // }
}