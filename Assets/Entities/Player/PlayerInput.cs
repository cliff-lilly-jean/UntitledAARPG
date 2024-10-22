
using UnityEngine;


public class PlayerInput : MonoBehaviour
{
    [SerializeField] private MovementData _movementData;
    private GameControls _controls;


    private void Awake()
    {
        _controls = new GameControls();
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _controls.Player.Move.performed += _ => GetDirection();
        _controls.Player.Move.canceled += _ => ResetDirection();
    }


    private void OnEnable()
    {
        _controls.Enable();
    }

    private void OnDisable()
    {
        _controls.Disable();
    }

    private void GetDirection()
    {
        _movementData.direction = _controls.Player.Move.ReadValue<Vector2>();

    }

    private void ResetDirection()
    {
        _movementData.direction = Vector2.zero;
    }
}
