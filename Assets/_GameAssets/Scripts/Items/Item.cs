using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum ItemValues { LlaveAmarilla, GemaAmarilla, Uninvisible, Invulnerabilidad, Escalator, DobleSalto }

    [SerializeField]
    private ItemValues itemName;

    public BoxCollider2D colJugador;

    public BoxCollider2D colItem;

    public AudioClip sonidoItem;
    public AudioSource audioSource;
    private void Start()
    {
        Physics2D.IgnoreCollision(colJugador, colItem, true);
    }
    private void OnTriggerEnter2D(Collider2D collision)

    {
        Physics2D.IgnoreCollision(colJugador, colItem, true);

        if (collision.gameObject.CompareTag("Player"))
        {
            audioSource.PlayOneShot(sonidoItem);

            Destroy(transform.parent.gameObject);
            GameManager gm = GameManager.Instance;
            gm.AddItem(gameObject);

        }


    }
    public ItemValues GetItemName()
    {
        return this.itemName;
    }
}
