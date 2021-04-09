using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puertas : MonoBehaviour
{

    public GameObject puerta;

    public float tiempoEspera;

    private bool abierta = false;

    public GameObject palancaActiva;
    public GameObject palancaNoActiva;

    public Transform posicionPalanca;







    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Invoke("Abrir", tiempoEspera);
            Destroy(palancaNoActiva, tiempoEspera);
            GameObject PalancaDada = Instantiate(palancaActiva, posicionPalanca.position, posicionPalanca.rotation);

        }
        print("KEmaNimo");

    }



    private void Abrir()
    {
        puerta.GetComponentInChildren<Animator>().enabled = true;

        // puerta.GetComponent<BoxCollider2D>().enabled = false;
        print("KEmaNimo");
        abierta = true;
    }


    // Update is called once per frame

}
