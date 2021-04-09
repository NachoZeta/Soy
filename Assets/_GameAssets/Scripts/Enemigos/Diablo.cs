using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diablo : MonoBehaviour
{
    public int danyo;
    public bool picorro = true;
    public float tiempoReactivacion;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!picorro) return;
        if (other.gameObject.CompareTag("Player"))
        {
            GetComponentInParent<ElementoMovil>().CambiarSentido();
            picorro = false;
            Invoke("Reactivar", tiempoReactivacion);
            //Hacer danyo a través del GameManager
            GameManager gm = GameManager.Instance;
            gm.HacerDanyo(danyo);


        }
    }
    private void Reactivar()
    {
        picorro = true;
    }
}
