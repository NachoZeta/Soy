using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFinJuego : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            GameManager gm = GameManager.Instance;
            gm.JuegoAcabado();
        }

    }
}

