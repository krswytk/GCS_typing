using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GetClickedText : MonoBehaviour, IPointerClickHandler
{
    private int number;
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
        Debug.Log(number);
        mean.meanNumber = number;
    }

    public void setNumber(int n)
    {
        number = n;
    }
}
