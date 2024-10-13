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
    }


    private void Move()
    {
        rb.linearVelocity = new Vector2(movementData.direction.x, movementData.direction.y) * movementData.speed;

        animator.SetFloat("horizontal", movementData.direction.x);
        animator.SetFloat("vertical", movementData.direction.y);

    }
}