using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GetClickedText : MonoBehaviour, IPointerClickHandler
{
    public int number;
    public mean meanObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       

    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Ok");
        meanObject.meanNumber = number;
    }
}
