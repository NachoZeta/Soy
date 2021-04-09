using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Animator animator;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ActivarCheckpoint(collision.transform.position);
        }
    }

    void ActivarCheckpoint(Vector3 posicionPlayer)
    {
        animator.SetTrigger("salvado");
        GameManager gm = GameManager.Instance;
        gm.GuardarCheckpoint(posicionPlayer);
    }
}
