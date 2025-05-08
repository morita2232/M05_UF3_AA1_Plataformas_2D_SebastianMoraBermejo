using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSounds : MonoBehaviour, IPointerEnterHandler
{
    private AudioSource sel;

    void Start()
    {
        sel = GetComponent<AudioSource>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        sel.Play();
        EventSystem.current.SetSelectedGameObject(null); // Desactivar selecci�n al usar el rat�n
    }
}
