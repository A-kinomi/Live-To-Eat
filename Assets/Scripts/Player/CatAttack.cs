using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class CatAttack : MonoBehaviour
{
    PlayerMovement playerMovementScript;

    void Start()
    {
        playerMovementScript = GetComponentInParent<PlayerMovement>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
    }
}
