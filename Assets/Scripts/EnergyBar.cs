using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnergyBar : MonoBehaviour
{
    float maxEnergy = 2000f; //change this later
    float currentEnergy;

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

    public void TakeFoodCalorie(float calorie)
    {
        currentEnergy = Mathf.Clamp(currentEnergy + calorie, 0, maxEnergy);
        EnergyBarChange();
    }

    public void ConsumeEnergy(float calConsume)
    {
        currentEnergy = Mathf.Clamp(currentEnergy - calConsume, 0, maxEnergy);
        EnergyBarChange();
    }
}
