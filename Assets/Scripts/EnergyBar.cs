using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnergyBar : MonoBehaviour
{
    float maxEnergy = 2000f; //change this later
    public float initialEnergy = 800f;
    public float currentEnergy;
    public float underwight;
    public float overwight;

    Slider energySlider;
    [SerializeField] TextMeshProUGUI calorieNumberText;

    private void Start()
    {
        energySlider = GetComponent<Slider>();
        energySlider.maxValue = maxEnergy;
        currentEnergy = initialEnergy;
        EnergyBarChange();

        underwight = maxEnergy * 0.25f;
        overwight = maxEnergy * 0.7f;
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
