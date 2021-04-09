using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementoMovil : MonoBehaviour
{
    public GameObject objetoAMover;
    public Transform origen;
    public Transform destino;
    [SerializeField]
    private float speed;
    public float tiempoPausa;
    public bool rotacion;
    private float delta = 0;
    private bool enPausa = false;

    void Update()
    {
        if (objetoAMover != null)
        {
            if (enPausa) return;

            if (rotacion)
            {
                //Expresión ternaria
                objetoAMover.transform.localScale = speed > 0 ? new Vector3(-1, 1, 1) : new Vector3(1, 1, 1);

                //If-else de toda la vida
                /*
                if (speed > 0)
                {
                    objetoAMover.transform.localScale = new Vector3(-1, 1, 1);
                }
                else
                {
                    objetoAMover.transform.localScale = new Vector3(1, 1, 1);
                }
                */
            }


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
    public void CambiarSentido()
    {
        speed = -speed;
    }
}
