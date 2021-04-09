using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestorPoderes : MonoBehaviour
{
    private bool desinvilizado = false;
    private bool dobleSaltado = false;

    public bool desescalado = false;
    private Mover2 central;

    [SerializeField]
    public Player jugador;

    //public void Update()
    //{
    // GameManager gm = GameManager.Instance;
    //if (gm.HasItem(Item.ItemValues.Escalator))
    //{
    //  desescalado = true;
    //print("Tengo el escalator");


    //}
    //}

    public void PilloEscala()
    {
        GameManager gm = GameManager.Instance;
        if (gm.HasItem(Item.ItemValues.Escalator))
        {
            desescalado = true;
            print("Tengo el puto escalador");
        }
    }

    public bool Escalamos()
    {
        return desescalado;
    }
}
