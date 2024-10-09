using UnityEngine;

public class Move : MonoBehaviour
{
    public MovementData movementData;
    private GameControls controls;


    private Rigidbody2D rb;

    private void Awake()
    {
        controls = new GameControls();


    }

    private void OnEnable()
    {
        controls.Enable();

        controls.Player.Move.performed += _ => UpdateMoveDirection();
        controls.Player.Move.canceled += _ => ResetMoveDirection();
    }

    private void OnDisable()
    {
        controls.Disable();

        controls.Player.Move.performed -= _ => UpdateMoveDirection();
        controls.Player.Move.canceled -= _ => ResetMoveDirection();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movementData.speed = movementData.maxSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetMoveDirection();

        Debug.Log(movementData.direction);
    }

    private void GetMoveDirection()
    {
        movementData.direction = controls.Player.Move.ReadValue<Vector2>();
    }

    private void UpdateMoveDirection()
    {
        rb.linearVelocity = new Vector2(movementData.direction.x, movementData.direction.y) * movementData.speed;

    }

    private void ResetMoveDirection()
    {
        rb.linearVelocity = Vector2.zero;
    }
}
