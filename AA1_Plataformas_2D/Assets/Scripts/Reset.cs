using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    public GameObject player;
    public Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(ResetPlayer());
        }
    }

    IEnumerator ResetPlayer()
    {
        Debug.Log("Inicia muerte");
        animator.SetBool("isDead", true);

        yield return new WaitForSeconds(2f);

        Debug.Log("Reinicio de posición");
        player.transform.position = new Vector3(-3, 0, -2);
        animator.SetBool("isDead", false);
    }

}

