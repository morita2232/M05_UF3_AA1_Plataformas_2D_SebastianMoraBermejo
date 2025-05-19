using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fin : MonoBehaviour
{

    float levelTimer = 0f;
    bool isLevelRunning = true;
    public GameObject win;
    public GameObject witch;
    [SerializeField] TMPro.TMP_Text timeDisplay;

    void Update()
    {
        if (isLevelRunning)
        {
            levelTimer += Time.deltaTime;
        }
    }

    void ShowLevelTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        timeDisplay.text = $"You did it in: {minutes:00}:{seconds:00}";
    }
    void OnLevelComplete()
    {
        isLevelRunning = false;
        win.SetActive(true);
        witch.SetActive(false);
        ShowLevelTime(levelTimer);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            OnLevelComplete();
        }
    }
}
