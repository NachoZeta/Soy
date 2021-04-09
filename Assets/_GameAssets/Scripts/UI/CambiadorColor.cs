using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CambiadorColor : MonoBehaviour
{
    Color colorInicial;
    void Start()
    {
        colorInicial = GetComponentInParent<Text>().color;
    }

    public void SetColorAmarillo()
    {
        GetComponentInParent<Text>().color = new Color(1, 1, 0);
    }
    public void SetColorInicial()
    {
        GetComponentInParent<Text>().color = colorInicial;
    }
}
