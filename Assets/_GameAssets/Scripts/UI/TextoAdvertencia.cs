using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextoAdvertencia : MonoBehaviour
{
    [Header("El tiempo que va a estar visible el texto (en segundos)")]
    public float tiempoPresentacion;
    private Text textoAdvertencia;
    private void Awake()
    {
        textoAdvertencia = GetComponent<Text>();
    }
    void Start()
    {
        textoAdvertencia.enabled = false;
    }
    public void SetTexto(string texto)
    {
        textoAdvertencia.enabled = true;
        textoAdvertencia.text = texto;
        Invoke("Desactivar", tiempoPresentacion);
    }
    private void Desactivar()
    {
        textoAdvertencia.enabled = false;
    }
}
