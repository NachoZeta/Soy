using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuenteTrampa : MonoBehaviour
{
    public float tiempoEspera;
    private bool haCaido = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("Caer", tiempoEspera);
        }
    }
    private void Caer()
    {
        GetComponent<Animator>().enabled = true;
        haCaido = true;
    }

    private void OnBecameInvisible()
    {
        if (haCaido)
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
