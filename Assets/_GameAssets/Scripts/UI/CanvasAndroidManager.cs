using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasAndroidManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager gameManager = GameManager.Instance;
        bool isAndroid = gameManager.IsAndroid();
        if (!isAndroid)
        {
            GameObject.Find("Fixed Joystick").SetActive(false);
            GameObject.Find("AButton").SetActive(false);
            GameObject.Find("BButton").SetActive(false);
            GameObject.Find("ExitButton").SetActive(false);
        }
    }
}
