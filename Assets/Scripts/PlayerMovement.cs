using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;

    private Vector2 moveInput;
    private Rigidbody2D myRigidbody;
    CircleCollider2D myCollider;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        MoveHorizontal();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void MoveHorizontal()
    {
        myRigidbody.linearVelocity = new Vector2(moveInput.x * runSpeed, myRigidbody.linearVelocity.y);
    }

    void OnJump(InputValue value)
    {
        if(!myCollider.IsTouchingLayers(LayerMask.GetMask("Platform")))
        {
            return; //to prevent infinit jump
        }

        if(value.isPressed)
        {
            myRigidbody.linearVelocity += new Vector2(0f, jumpSpeed);
        }
    }
}
