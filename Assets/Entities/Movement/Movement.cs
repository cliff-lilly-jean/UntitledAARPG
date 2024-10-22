using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] private MovementData _movementData;
    public Rigidbody2D _rb;

    private void Start()
    {
        _movementData.speed = _movementData.maxSpeed;
    }

    // TODO: create OnMove, OnDash delegates and events to allow modularity

    void FixedUpdate()
    {
        Move();
    }


    private void Move()
    {
        _rb.linearVelocity = new Vector2(_movementData.direction.x, _movementData.direction.y) * _movementData.speed;
    }
}