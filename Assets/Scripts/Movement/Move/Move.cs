using UnityEngine;

public class Move : MonoBehaviour
{
    public MovementData movementData;
    public Animator animator;
    public Rigidbody2D rb;

    private GameControls controls;


    private void Awake()
    {
        controls = new GameControls();
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movementData.speed = movementData.maxSpeed;

        controls.Player.Move.performed += _ => GetMoveDirection();
        controls.Player.Move.canceled += _ => ResetMoveDirection();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateMoveDirection();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void GetMoveDirection()
    {
        movementData.direction = controls.Player.Move.ReadValue<Vector2>();
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

        animator.SetFloat("horizontal", horizontalMovement);
        animator.SetFloat("vertical", verticalMovement);
    }
}
