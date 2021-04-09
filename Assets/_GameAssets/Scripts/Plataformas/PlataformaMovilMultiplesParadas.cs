using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovilMultiplesParadas : MonoBehaviour
{
    public GameObject objetoAMover;
    public Transform[] paradas;
    public float speed;
    public float tiempoPausa;
    private float delta=0;
    private bool enPausa = false;
    private int paradaActual = 0;
    private int paradaSiguiente = 1;
    private int incActual=1;
    private int incSiguiente =1;

    void Update()
    {
        if (enPausa) return;
        delta += Time.deltaTime * speed;
        if (delta > 1)
        {
            delta = 0;
            Pausar();
            paradaActual+=incActual;
            paradaSiguiente+=incSiguiente;
            if (paradaSiguiente == paradas.Length)
            {
                incSiguiente = -incSiguiente;
                paradaSiguiente = paradaActual + incSiguiente;
            }
            if (paradaActual == paradas.Length)
            {
                incActual = -incActual;
                paradaActual = paradaSiguiente - incActual;
            }
            if (paradaSiguiente == -1)
            {
                paradaActual = 0;
                paradaSiguiente = 1;
                incActual = 1;
                incSiguiente = 1;
            }
        }
        Vector2 nuevaPosicion = Vector2.Lerp(paradas[paradaActual].position, paradas[paradaSiguiente].position, delta);
        objetoAMover.transform.position = nuevaPosicion;
    }
    void Pausar()
    {
        enPausa = true;
        Invoke("Restablecer", tiempoPausa);
    }
    void Restablecer()
    {
        enPausa = false;
    }
}
