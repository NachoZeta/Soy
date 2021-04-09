using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MagicalTextButton : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler
{
    Color colorInicial;
    public void OnPointerClick(PointerEventData eventData)
    {
        print("OnPointerClick");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        print("OnPointerDown");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        print("OnPointerEnter");
        GetComponent<Text>().color = new Color(1, 1, 0);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        print("OnPointerExit");
        GetComponent<Text>().color = colorInicial;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        print("OnPointerUp");
    }

    // Start is called before the first frame update
    void Start()
    {
        colorInicial = GetComponent<Text>().color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
