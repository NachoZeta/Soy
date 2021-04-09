using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticBG : MonoBehaviour
{
    [SerializeField]
    private Transform playerTransform;
    
    void LateUpdate()
    {
        transform.position = new Vector3(playerTransform.position.x, transform.position.y, transform.position.z);
    }
}
