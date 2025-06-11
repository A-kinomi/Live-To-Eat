using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FoodInfo : MonoBehaviour
{
    public Foods foods;
    public int calorie;

    TextMeshProUGUI calorieText;
    SpriteRenderer foodImage;

    void Start()
    {
        calorie = foods.calorie;
        calorieText = GetComponentInChildren<TextMeshProUGUI>();
        calorieText.text = foods.calorie.ToString();
        foodImage = gameObject.GetComponent<SpriteRenderer>();
        foodImage.sprite = foods.foodImage;
    }
}
