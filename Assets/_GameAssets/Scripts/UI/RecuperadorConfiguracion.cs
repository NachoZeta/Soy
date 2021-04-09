using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecuperadorConfiguracion : MonoBehaviour
{
    public Toggle conmutadorSonido;
    public Slider volumenSonido;
    private void Start()
    {
        if (PlayerPrefs.HasKey("sonido"))
        {
            bool sonido = bool.Parse(PlayerPrefs.GetString("sonido"));
            float volumen = PlayerPrefs.GetFloat("volumen");
            conmutadorSonido.isOn = sonido;
            volumenSonido.value = volumen;
            GameObject.Find("BackgroundMusic").GetComponent<MusicManager>().SetConfig(sonido, volumen);
        }
    }
}