using Unity.VisualScripting;
using UnityEngine;

public class FoodDrawnIn : MonoBehaviour
{
    [SerializeField] GameObject player;
    GameObject catMouth;
    [SerializeField] float foodSpeed = 1.0f;

    CircleCollider2D foodCoreCollider;
    PlayerMovement playerMovementScript;
    DrawIn drawInScript;

    public bool isEaten = false;

    void Start()
    {
        playerMovementScript = player.GetComponent<PlayerMovement>();
        drawInScript = player.GetComponentInChildren<DrawIn>();
        foodCoreCollider = GetComponentInChildren<CircleCollider2D>();
    }

    void FoodApproachesPlayer()
    {
        catMouth = GameObject.FindWithTag("CatMouth");
        transform.position = Vector2.MoveTowards(transform.position, catMouth.transform.position, foodSpeed * Time.deltaTime);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (playerMovementScript.isDrawingIn && drawInScript.isFoodNearBy)
            {
                isEaten = true;
                FoodApproachesPlayer();
            }
            if (!playerMovementScript.isDrawingIn)
            {
                isEaten = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isEaten = false;
        }
    }
}
