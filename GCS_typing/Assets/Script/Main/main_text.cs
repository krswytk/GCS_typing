using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class main_text : MonoBehaviour
{
    [SerializeField]
    private Text text;

    public GetText GetText;
    public Text_choice Text_choice;

    string[] del_ans = { "/" };
    string text_main;

    // Start is called before the first frame update
    void Start()
    {
        text_change();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void text_change()
    {
        string[] ans = GetText.text[Text_choice.problem_num].Split(del_ans, StringSplitOptions.None);
        ans[1] = "[   ]";
        for (int i = 0; i < 3; i++)
        {
            text_main = String.Concat(text_main, ans[i]);
        }
        Debug.Log(text_main);
        text.text = text_main;
        text_main = text_main.Remove(0, text_main.Length);
    }
}
