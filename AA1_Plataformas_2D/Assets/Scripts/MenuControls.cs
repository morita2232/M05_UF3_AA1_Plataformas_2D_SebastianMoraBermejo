using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControls : MonoBehaviour
{

    public GameObject credits;
    public GameObject menu;
    public void Begin()
    {
        SceneManager.LoadScene("Game");
    }

    public void Credits()
    {
        menu.SetActive(false);
        credits.SetActive(true);   
    }

    public void Menu()
    {
        menu.SetActive(true);
        credits.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
