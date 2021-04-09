using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour
{
    //Deberes: HACER QUE EL PROYECTIL MATE A LOS ENEMIGOS, CADENCIA DE DISPARO, HACER MÁS ENEMIGOS

    public float rotationSpeed;
    public float timeToDestroy;

    private BoxCollider2D colisionador;

    private Animator animator;

    private GameObject principio;

    private GameObject fin;

    private PlataformaMovil demonio;





    void Update()
    {
        transform.Rotate(0, 0, Time.deltaTime * rotationSpeed);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(transform.parent.gameObject, timeToDestroy);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            if (collision.gameObject != null)
            {
                animator = collision.gameObject.GetComponent<Animator>();
                colisionador = collision.gameObject.GetComponent<BoxCollider2D>();
                demonio = collision.gameObject.GetComponent<PlataformaMovil>();

                animator.SetTrigger("morir");
                //Destroy(GameObject.FindWithTag("Limite"));
                
                Destroy(collision.gameObject, 0.5f);
                Destroy(colisionador);
                // demonio.enabled = false;
            }

        }
    }
}
