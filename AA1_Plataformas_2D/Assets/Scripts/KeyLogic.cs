using UnityEngine;

public class KeyLogic : MonoBehaviour
{
    public ChestLogic chest;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            chest.OpenChest();
            Destroy(gameObject); // destruir la llave
        }
    }
}
