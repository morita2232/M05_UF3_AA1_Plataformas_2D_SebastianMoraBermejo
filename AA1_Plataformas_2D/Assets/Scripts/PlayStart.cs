using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayStart : MonoBehaviour
{
    public GameObject game;
    public GameObject text;
    public GameObject witch;

    public void Started()
    {
        text.SetActive(false);
        game.SetActive(true);
        witch.SetActive(true);
    }
}
