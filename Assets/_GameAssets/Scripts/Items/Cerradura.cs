using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cerradura : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager gm = GameManager.Instance;
            if (gm.HasItem(Item.ItemValues.LlaveAmarilla))
            {
                GameObject.Find("TextAdvertencia").GetComponent<TextoAdvertencia>().SetTexto("YOU WIN!");
            }
            else
            {
                GameObject.Find("TextAdvertencia").GetComponent<TextoAdvertencia>().SetTexto("Yellow key required");
            }
        }
    }
}
