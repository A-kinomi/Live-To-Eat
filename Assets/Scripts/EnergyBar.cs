using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnergyBar : MonoBehaviour
{
    int maxEnergy = 2000; //change this later
    int currentEnergy;

    Slider energySlider;
    [SerializeField] TextMeshProUGUI calorieNumberText;

    void Start()
    {
        energySlider = GetComponent<Slider>();
        energySlider.maxValue = maxEnergy;
        currentEnergy = 800; // change this later
        EnergyBarChange();
    }

    void EnergyBarChange()
    {
        energySlider.value = currentEnergy;
        calorieNumberText.text = currentEnergy.ToString();
    }

    public void TakeFoodCalorie(int calorie)
    {
        currentEnergy = Mathf.Clamp(currentEnergy + calorie, 0, maxEnergy);
        EnergyBarChange();
        print(currentEnergy);
    }
}
