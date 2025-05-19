using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoorLock : MonoBehaviour
{

    public GameObject door;
    public BoxCollider2D doorCollider;
    public IngredientCounter count;
    public TextMeshProUGUI warning;
    public GameObject showWarning;
    private int fullCount = 5;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if( count.count == 5)
            {
                warning.text = "YOU CAN GO IN!";
                showWarning.SetActive(true);
                doorCollider.isTrigger = true;
                Debug.Log("PUERTA DESBLOQUEADA");
            }
            else if( count.count < 5)
            {
                warning.text = "YOU ARE MISSING " + (fullCount - count.count) + " INGREDIENTS";
                showWarning.SetActive(true);   
                Debug.Log("PUERTA BLOQUEADA");
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           showWarning.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            warning.text = "YOU CAN GO IN!";
            showWarning.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            showWarning.SetActive(false);
        }
    }

}
