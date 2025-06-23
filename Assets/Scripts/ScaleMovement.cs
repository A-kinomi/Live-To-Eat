using UnityEngine;
using UnityEngine.TextCore.Text;

public class ScaleMovement : MonoBehaviour
{
    Rigidbody2D scaleRigidbody;
    [SerializeField] float jumpHight = 3f;

    int randomNumber;
    [SerializeField] float moveDistance = 3f;

    [SerializeField] float time;
    float interval = 3f;
   
    void Start()
    {
        scaleRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        time += Time.deltaTime;
        if(time > interval)
        {
            time = 0f;
            randomNumber = Random.Range(0,2);
            EnemyMove();
            EnemyJump();
        }
    }

    void EnemyMove()
    {
        if(randomNumber == 0) //go to the right
        {
            scaleRigidbody.AddForce(new Vector2(moveDistance, 0f));
        }
        if(randomNumber == 1) //go to the left
        {
            scaleRigidbody.AddForce(new Vector2(-moveDistance, 0f));
        }
    }

    void EnemyJump()
    {
        scaleRigidbody.linearVelocity = new Vector2(0, jumpHight);
    }
}
