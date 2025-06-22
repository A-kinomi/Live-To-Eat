using UnityEngine;

public class MovableBlocks : MonoBehaviour
{
    Rigidbody2D movableBlockRigidbody;
    [SerializeField] GameObject player;
    BodySizeChange bodySizeChangeScript;

    void Start()
    {
        movableBlockRigidbody = GetComponent<Rigidbody2D>();
        bodySizeChangeScript = player.GetComponent<BodySizeChange>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(bodySizeChangeScript.isLsize && collision.gameObject.tag == "Player")
        {
            movableBlockRigidbody.bodyType = RigidbodyType2D.Dynamic;
        }
        if(!bodySizeChangeScript.isLsize && collision.gameObject.tag == "Player")
        {
            movableBlockRigidbody.bodyType = RigidbodyType2D.Static;
        }
    }
}
