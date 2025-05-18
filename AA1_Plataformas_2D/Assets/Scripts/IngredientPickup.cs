using UnityEngine;

public class IngredientPickup : MonoBehaviour
{
    public int spriteIndex = 0; // Set this in the Inspector for each prefab

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            IngredientCounter counter = FindObjectOfType<IngredientCounter>();
            if (counter != null)
            {
                counter.AddIngredient(spriteIndex);
            }

            Destroy(gameObject);
        }
    }
}


