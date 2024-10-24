
using UnityEngine;


public class InputControls : MonoBehaviour
{
    private Movement _movement;
    private Controls _controls;


    private void Awake()
    {
        _controls = new Controls();
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _controls.Player.Move.performed += _ => HandleMove();
        _controls.Player.Move.canceled += _ => _movement.ResetDirection();

        _movement = GetComponent<Movement>();
    }

    private void Update()
    {

        Debug.Log("Input Controller: " + _controls.Player.Move.ReadValue<Vector2>());
    }


    private void OnEnable()
    {
        _controls.Enable();
    }

    private void OnDisable()
    {
        _controls.Disable();
    }

    private void HandleMove()
    {
        Vector2 moveDirection = _controls.Player.Move.ReadValue<Vector2>();

        _movement.SetDirection(moveDirection);
    }


}
