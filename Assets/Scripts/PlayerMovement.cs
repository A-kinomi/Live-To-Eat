using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;

    private Vector2 moveInput;
    private Rigidbody2D myRigidbody;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
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
        if(/*collider doesnt touch gound. use IsTouchingLayers(LayerMas.GetMask("Ground"))*/)
        {
            return; //to prevent infinit jump
        }

        if(value.isPressed)
        {
            myRigidbody.linearVelocity += new Vector2(0f, jumpSpeed);
        }
    }
}
