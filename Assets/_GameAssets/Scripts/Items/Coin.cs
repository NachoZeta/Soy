using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int puntuacion;
    public GameObject prefabPoints;

    public AudioSource audioSource;
    public AudioClip sonidoMoneda;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            // audioSource.PlayOneShot(sonidoMoneda);
            GameManager gm = GameManager.Instance;
            gm.AddPuntuacion(puntuacion);
            //Puntuación volante?
            (Instantiate(prefabPoints, transform.position, transform.rotation)).
                GetComponent<FlyingScore>().SetScoreValue(puntuacion);

            //Equivalente a la línea anterior
            /*
            GameObject puntosVoladores = Instantiate(prefabPoints, transform.position, transform.rotation);
            puntosVoladores.GetComponent<FlyingScore>().SetScoreValue(puntuacion);
            */
            //Destrucción de la moneda
            Destroy(transform.parent.gameObject);
        }
    }
}
