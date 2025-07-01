using UnityEngine;

public class FoodCore : MonoBehaviour
{
    GameObject food;
    FoodDrawnIn foodDrawInScript;

    [SerializeField] GameObject energyBar;
    EnergyBar energyBarScript;

    FoodInfo foodInfoscript;
    float foodCalorie;

    [SerializeField] GameObject foodPosition;
    [SerializeField] float foodBackSpeed = 1.0f;

    void Start()
    {
        food = transform.parent.gameObject;
        foodDrawInScript = food.GetComponent<FoodDrawnIn>();
        foodInfoscript = food.GetComponent<FoodInfo>();
        energyBarScript = energyBar.GetComponent<EnergyBar>();
    }

    private void Update()
    {
        if(foodPosition == null)
        {
            return;
        }
        if (transform.position == foodPosition.transform.position)
        {
            return;
        }
        if (!foodDrawInScript.isEaten)
        {
            food.transform.position = Vector2.MoveTowards(food.transform.position, foodPosition.transform.position, foodBackSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            foodCalorie = foodInfoscript.calorie;

            if (foodDrawInScript.isEaten)
            {
                energyBarScript.TakeFoodCalorie(foodCalorie);
                Destroy(food);
            }
        }
    }
}
