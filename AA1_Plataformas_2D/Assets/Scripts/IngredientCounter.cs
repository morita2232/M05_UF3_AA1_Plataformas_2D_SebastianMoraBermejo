using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class IngredientCounter : MonoBehaviour
{
    public TextMeshProUGUI counterText;
    public Sprite[] sprites;
    public Transform iconContainer;
    public GameObject iconPrefab;
    public MovingPlatform platform;

    public int count = 0;

    public void AddIngredient(int spriteIndex)
    {
        count++;
        counterText.text = "Ingredients: " + count;

        GameObject newIcon = Instantiate(iconPrefab, iconContainer);
        newIcon.GetComponent<Image>().sprite = sprites[spriteIndex];

        if (count == 4)
        {
            platform.ActivatePlatform();
        }
    }
}
