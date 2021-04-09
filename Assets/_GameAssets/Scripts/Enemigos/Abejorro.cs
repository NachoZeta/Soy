using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abejorro : MonoBehaviour
{
    public int danyo;
    public bool picorro = true;
    public float tiempoReactivacion;

    public bool invencible = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!picorro) return;
        if (collision.gameObject.CompareTag("Player"))
        {
            if (invencible == false)
            {
                GetComponentInParent<ElementoMovil>().CambiarSentido();
                picorro = false;
                Invoke("Reactivar", tiempoReactivacion);
                //Hacer danyo a través del GameManager
                GameManager gm = GameManager.Instance;
                gm.HacerDanyo(danyo);
            }

            if (invencible == true)
            {
                GetComponentInParent<ElementoMovil>().CambiarSentido();
                picorro = false;
                Invoke("Reactivar", tiempoReactivacion);

            }

        }
    }
    private void Reactivar()
    {
        picorro = true;
    }
}
