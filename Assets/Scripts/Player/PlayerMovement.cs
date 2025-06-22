using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float runSpeed;
    public float jumpSpeed;

    private Vector2 moveInput;
    private Rigidbody2D myRigidbody;
    BoxCollider2D myCollider;

    DrawIn drawInScript;
    public bool isDrawingIn = false;

    [SerializeField] GameObject energyBar;
    EnergyBar energyBarscript;

    bool isMoving = false;
    [SerializeField] float calConsume = 0.005f;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<BoxCollider2D>();
        drawInScript = GetComponentInChildren<DrawIn>();
        energyBarscript = energyBar.GetComponent<EnergyBar>();
    }

    void Update()
    {
        MoveHorizontal();
        FlipSprit();
        UseEnergyToMove();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        isMoving = true;
    }

    void MoveHorizontal()
    {
        if (isDrawingIn)
        {
            return; //player doesn't move while drawing in.
        }
        myRigidbody.linearVelocity = new Vector2(moveInput.x * runSpeed, myRigidbody.linearVelocity.y);
    }

    void OnStopMoving()
    {
        isMoving = false;
    }

    void UseEnergyToMove()
    {
        if(isMoving)
        {
            energyBarscript.ConsumeEnergy(calConsume); //reduce energy when moving around
        }
    }

    void FlipSprit()
    {
        //bool hasHolizontalSpeed = Mathf.Abs(myRigidbody.linearVelocity.x) > Mathf.Epsilon;
        bool hasHolizontalSpeed = Mathf.Abs(myRigidbody.linearVelocity.x) > 0.5;
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
        /*if (isDrawingIn)
        {
            return; //player doesn't jump while drawing in.
        }*/

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
