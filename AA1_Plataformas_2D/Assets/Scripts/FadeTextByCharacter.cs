using UnityEngine;
using TMPro;
using System.Collections;

public class FadeTextByCharacter : MonoBehaviour
{
    public float delayPerCharacter = 0.05f;

   // public GameObject button1; // Arrastra aqu� el primer bot�n
    //public GameObject button2; // Arrastra aqu� el segundo bot�n

    private TextMeshProUGUI textMesh;

    void OnEnable()
    {
        textMesh = GetComponent<TextMeshProUGUI>();

        if (textMesh != null)
        {
            textMesh.ForceMeshUpdate();
            textMesh.maxVisibleCharacters = 0;
            StartCoroutine(RevealCharacters());
        }
    }

    IEnumerator RevealCharacters()
    {
        int totalCharacters = textMesh.textInfo.characterCount;

        for (int i = 0; i <= totalCharacters; i++)
        {
            textMesh.maxVisibleCharacters = i;
            yield return new WaitForSeconds(delayPerCharacter);
        }

        // Activa los botones al terminar
//        if (button1 != null) button1.SetActive(true);
  //      if (button2 != null) button2.SetActive(true);
    }
}
