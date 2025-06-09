using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;

    private Vector2 moveInput;
    private Rigidbody2D myRigidbody;
    CapsuleCollider2D myCollider;

    DrawIn drawInScript;
    public bool isDrawingIn = false;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<CapsuleCollider2D>();
        drawInScript = GetComponentInChildren<DrawIn>();
    }

    void Update()
    {
        MoveHorizontal();
        FlipSprit();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void MoveHorizontal()
    {
        if (isDrawingIn)
        {
            return; //player doesn't move while drawing in.
        }
        myRigidbody.linearVelocity = new Vector2(moveInput.x * runSpeed, myRigidbody.linearVelocity.y);
    }

    void FlipSprit()
    {
        bool hasHolizontalSpeed = Mathf.Abs(myRigidbody.linearVelocity.x) > Mathf.Epsilon;

        if (hasHolizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidbody.linearVelocity.x), 1f);
        }
    }

    void OnJump(InputValue value)
    {
        if(!myCollider.IsTouchingLayers(LayerMask.GetMask("Platform")))
        {
            return; //to prevent infinit jump
        }
        if (isDrawingIn)
        {
            return; //player doesn't jump while drawing in.
        }

        if (value.isPressed)
        {
            myRigidbody.linearVelocity += new Vector2(0f, jumpSpeed);
        }
    }

    void OnDrawIn(InputValue value)
    {
        isDrawingIn = true;
    }

    void OnDrawInStop (InputValue value)
    {
        isDrawingIn = false;
    }
}
