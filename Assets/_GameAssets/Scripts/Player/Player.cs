using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void Awake()
    {
        if (PlayerPrefs.HasKey("x"))
        {
            float x = PlayerPrefs.GetFloat("x");
            float y = PlayerPrefs.GetFloat("y");
            float z = PlayerPrefs.GetFloat("z");
            transform.position = new Vector3(x, y, z);
        }
    }

   
}
