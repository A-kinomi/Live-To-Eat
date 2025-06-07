using UnityEngine;

public class FoodCore : MonoBehaviour
{
    GameObject food;
    FoodDrawnIn foodDrawInScript;


    void Start()
    {
        food = transform.parent.gameObject;
        foodDrawInScript = food.GetComponent<FoodDrawnIn>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (foodDrawInScript.isEaten)
            {
                Destroy(food);
            }
        }
    }
}
