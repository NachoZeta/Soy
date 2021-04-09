using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FijadorPlataformas : MonoBehaviour
{



    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pegajoso"))
        {
            transform.SetParent(collision.gameObject.transform);
        }


    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.SetParent(null);
    }
}