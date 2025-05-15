using UnityEngine;

public class IngredientPickup : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            IngredientCounter counter = FindObjectOfType<IngredientCounter>();
            if (counter != null)
            {
                counter.AddIngredient();
            }

            Destroy(gameObject); // Or setActive(false) if you prefer
        }
    }
}

