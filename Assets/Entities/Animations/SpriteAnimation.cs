using UnityEngine;

public class SpriteAnimation : MonoBehaviour
{

    [SerializeField] private MovementData _movementData;
    [SerializeField] private Animator _animator;


    void FixedUpdate()
    {
        ChangeAnimationDirection();
    }


    private void ChangeAnimationDirection()
    {
        // change to move animations if moving
        // if (_movementData.direction != Vector2.zero)
        // {
        //     _animator.SetBool("isMoving", true);

        //     _animator.SetFloat("horizontal", _movementData.direction.x);
        //     _animator.SetFloat("vertical", _movementData.direction.y);
        // }

        // // return to idle animations if not moving
        // if (_movementData.direction == Vector2.zero)
        // {
        //     _animator.SetBool("isMoving", false);
        // }
    }
}