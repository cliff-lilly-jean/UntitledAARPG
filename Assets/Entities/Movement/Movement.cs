using UnityEngine;

public class Movement : MonoBehaviour
{

    [SerializeField] private float _speed;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private Vector2 _direction;

    public Rigidbody2D _rb;

    private void Start()
    {
        _speed = _maxSpeed;
    }

    private void FixedUpdate()
    {
        Move();
    }


    private void Move()
    {
        _rb.linearVelocity = new Vector2(_direction.x, _direction.y) * _speed;
    }

    public Vector2 GetDirection()
    {
        return _direction;
    }

    public Vector2 SetDirection(Vector2 newDirection)
    {
        return _direction = newDirection;
    }

    public float GetSpeed()
    {
        return _speed;
    }

    public float SetSpeed(float newSpeed)
    {
        return _speed = newSpeed;
    }

    public float GetMaxSpeed()
    {
        return _maxSpeed;
    }

    public float SetMaxSpeed(float newMaxSpeed)
    {
        // TODO: add some checks, or if statement on types of things that can set MaxSpeed
        return _maxSpeed = newMaxSpeed;
    }

    public void ResetDirection()
    {
        _direction = Vector2.zero;
    }
}