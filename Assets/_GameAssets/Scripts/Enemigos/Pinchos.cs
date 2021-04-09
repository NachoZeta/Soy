using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinchos : MonoBehaviour
{
    public int danyo;

    public int danyoestatico;
    public bool picorro = true;
    public float tiempoReactivacion;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!picorro) return;
        if (collision.gameObject.CompareTag("Player"))
        {
            picorro = false;
            Invoke("Reactivar", tiempoReactivacion);
            GameManager gm = GameManager.Instance;
            gm.HacerDanyo(danyo);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!picorro) return;
        if (collision.gameObject.CompareTag("Player"))
        {
            picorro = false;
            GameManager gm = GameManager.Instance;
            gm.HacerDanyo(danyoestatico);
        }
    }


    private void Reactivar()
    {
        picorro = true;
    }
}
