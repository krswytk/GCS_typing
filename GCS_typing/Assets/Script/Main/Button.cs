using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{

    public Text_choice Text_choice;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        Text_choice.text_Button(0);
    }

    public void OnClick2()
    {
        Text_choice.text_Button(1);
    }

    public void OnClick3()
    {
        Text_choice.text_Button(2);
    }

    public void OnClick4()
    {
        Text_choice.text_Button(3);
    }
}
