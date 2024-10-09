using UnityEngine;

public class Move : MonoBehaviour
{
    public MovementData movementData;


    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(movementData.maxSpeed);
    }
}
