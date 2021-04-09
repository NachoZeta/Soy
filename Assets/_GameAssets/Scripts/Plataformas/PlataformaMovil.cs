using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovil : MonoBehaviour
{
    public GameObject objetoAMover;
    public Transform origen;
    public Transform destino;
    public float speed;
    public float tiempoPausa;
    private float delta = 0;
    private bool enPausa = false;

    void Update()
    {
        if (objetoAMover != null)
        {
            if (enPausa) return;
            delta += Time.deltaTime * speed;
            if (delta > 1)
            {
                delta = 1;
                speed = -speed;
                Pausar();
            }
            if (delta < 0)
            {
                delta = 0;
                speed = -speed;
                Pausar();
            }
            Vector2 nuevaPosicion = Vector2.Lerp(origen.position, destino.position, delta);
            objetoAMover.transform.position = nuevaPosicion;
        }
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
