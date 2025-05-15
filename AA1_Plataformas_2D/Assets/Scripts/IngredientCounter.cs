using UnityEngine;
using TMPro;

public class IngredientCounter : MonoBehaviour
{
    public TextMeshProUGUI counterText;
    private int count = 0;

    public void AddIngredient()
    {
        count++;
        counterText.text = "Ingredients: " + count;
    }
}
