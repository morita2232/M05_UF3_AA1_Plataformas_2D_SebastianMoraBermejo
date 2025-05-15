using UnityEngine;
using System.Collections; // Needed for IEnumerator

public class ChestLogic : MonoBehaviour
{
    public Animator chestAnimator;
    public GameObject ingredient;

    void Start()
    {
        ingredient.SetActive(false);
    }

    public void OpenChest()
    {
        StartCoroutine(OpenChestCoroutine());
    }

    private IEnumerator OpenChestCoroutine()
    {
        chestAnimator.SetBool("hasKey", true);

        // Wait until the animation is done
        yield return new WaitForSeconds(2f);

        ingredient.SetActive(true);
        ingredient.transform.position = new Vector3(14, 0, 0);
    }
}


