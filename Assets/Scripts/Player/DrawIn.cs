using UnityEngine;
using UnityEngine.InputSystem;

public class DrawIn : MonoBehaviour
{
    public bool isFoodNearBy = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Foods")
        {
            isFoodNearBy = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Foods")
        {
            isFoodNearBy = false;
        }
    }
}
