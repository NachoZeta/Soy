using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager _instance;
    public static MusicManager Instance { get { return _instance; } }//No haría falta (por ahora)
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void SetConfig(bool isEnabled, float volume)
    {
        AudioListener.volume = volume;
        if (!isEnabled)
        {
            AudioListener.volume = 0;
        }
    }
}
