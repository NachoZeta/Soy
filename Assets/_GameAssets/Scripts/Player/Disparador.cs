using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparador : MonoBehaviour
{
    public GameObject prefabProyectil;
    public Transform puntoSpawn;
    public float fuerzaDisparo;
    public float fuerzaVertical;
    private GameManager gameManager;

    public AudioSource audioSource;
    public AudioClip sonidoDisparo;
    private void Start()
    {
        gameManager = GameManager.Instance;
    }
    void Update()
    {
        if (gameManager.IsAndroid() == false && Input.GetButtonDown("Fire2"))
        {
            Disparar();
        }
    }
    public void Disparar()
    {
        GameObject proyectil = Instantiate(prefabProyectil, puntoSpawn.position, puntoSpawn.rotation);
        proyectil.GetComponent<Rigidbody2D>().AddForce(new Vector2(fuerzaDisparo * transform.localScale.x, fuerzaVertical));
        audioSource.PlayOneShot(sonidoDisparo);
    }
}
