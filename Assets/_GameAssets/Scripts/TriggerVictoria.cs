using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerVictoria : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            GameManager gm = GameManager.Instance;
            gm.Victoria();
        }

    }

}