using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuardadorConfiguracion : MonoBehaviour
{
    public Toggle conmutadorSonido;
    public Slider volumenSonido;
    public void Guardar()
    {
        PlayerPrefs.SetString("sonido", conmutadorSonido.isOn.ToString());
        PlayerPrefs.SetFloat("volumen", volumenSonido.value);
        PlayerPrefs.Save();
        
        GameObject.Find("BackgroundMusic").GetComponent<MusicManager>().
            SetConfig(conmutadorSonido.isOn, volumenSonido.value);
    }
}
