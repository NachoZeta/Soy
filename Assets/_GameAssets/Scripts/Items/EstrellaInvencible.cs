using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstrellaInvencible : MonoBehaviour
{
    public bool invencibles;
    public AudioSource audioSource;
    public AudioClip sonidoInvul;

    public BoxCollider2D colJugador;
    public BoxCollider2D colItem;



    void Start()
    {
        invencibles = false;
        audioSource.time = 15f;
        Physics2D.IgnoreCollision(colJugador, colItem, true);


    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Physics2D.IgnoreCollision(colJugador, colItem, true);
        if (collision.gameObject.CompareTag("Player"))
        {
            invencibles = true;
            Destroy(transform.parent.gameObject, 1.0f);
            GameManager gm = GameManager.Instance;
            // gm.AddItem(gameObject);
            gm.Invencibilizador();
            Invoke("Devolvedor", 0.1f);
            audioSource.PlayOneShot(sonidoInvul);


        }

    }

    public bool Devolvedor()
    {
        return (invencibles);
    }
}



