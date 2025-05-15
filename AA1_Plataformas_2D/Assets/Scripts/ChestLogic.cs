using UnityEngine;

public class ChestLogic : MonoBehaviour
{
    public Animator chestAnimator;

    public void OpenChest()
    {
        chestAnimator.SetBool("hasKey", true);
    }
}

