using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaInvisible : MonoBehaviour
{
    public GameObject plataformainvisible;


    private void Start()
    {


        plataformainvisible.GetComponentInChildren<SpriteRenderer>().enabled = false;
        plataformainvisible.GetComponentInChildren<BoxCollider2D>().enabled = false;

    }

    private void Update()


    {
        GameManager gm = GameManager.Instance;
        if (gm.HasItem(Item.ItemValues.Uninvisible))
        {

            plataformainvisible.GetComponentInChildren<SpriteRenderer>().enabled = true;
            plataformainvisible.GetComponentInChildren<BoxCollider2D>().enabled = true;
        }

    }
}

