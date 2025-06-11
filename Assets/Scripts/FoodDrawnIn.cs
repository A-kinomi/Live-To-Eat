using Unity.VisualScripting;
using UnityEngine;

public class FoodDrawnIn : MonoBehaviour
{
    [SerializeField] GameObject player;
    float foodSpeed = 0.8f;

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
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, foodSpeed * Time.deltaTime);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (playerMovementScript.isDrawingIn && drawInScript.isFoodNearBy)
            {
                FoodApproachesPlayer();
                isEaten = true;
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
