using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SeleccionadorUIElement : MonoBehaviour
{
    private EventSystem eventSystem;
    private void Awake()
    {
        eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
    }
    private void OnEnable()
    {
        eventSystem.SetSelectedGameObject(gameObject);
    }
}
