using UnityEngine;
using UnityEngine.InputSystem;

public class DrawIn : MonoBehaviour //Player.DrawInArea
{
    public bool isFoodNearBy = false;

    private void OnTriggerStay2D(Collider2D collision)
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
