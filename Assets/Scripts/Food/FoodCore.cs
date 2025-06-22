using UnityEngine;

public class FoodCore : MonoBehaviour
{
    GameObject food;
    FoodDrawnIn foodDrawInScript;

    [SerializeField] GameObject energyBar;
    EnergyBar energyBarScript;

    FoodInfo foodInfoscript;
    float foodCalorie;

    void Start()
    {
        food = transform.parent.gameObject;
        foodDrawInScript = food.GetComponent<FoodDrawnIn>();
        foodInfoscript = food.GetComponent<FoodInfo>();
        energyBarScript = energyBar.GetComponent<EnergyBar>();
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
