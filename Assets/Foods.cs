using UnityEngine;

[CreateAssetMenu(fileName = "Foods", menuName = "Scriptable Objects/Foods")]
public class Foods : ScriptableObject
{
    public string foodName;
    public int calorie;
    public Sprite foodImage;
}
