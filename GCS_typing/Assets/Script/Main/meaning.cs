using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class meaning : MonoBehaviour
{
    [SerializeField]
    private Text Text_title;
    [SerializeField]
    private Text Text;
    [SerializeField]
    private TextAsset dictionary;

    string[] del_ans = { " " };
    string[] del = { "\r\n" };

    public GetText GetText;
    public Text_choice Text_choice;

    string text_main;

    string[] text_meaning;
    string[,] meaning_word;

    string[] num;

    void Start()
    {
        text_meaning = dictionary.text.Split(del, StringSplitOptions.None);
        meaning_word = new string[text_meaning.Length,3];
        for (int i = 0; i < text_meaning.Length; i++)
        {
            num = text_meaning[i].Split(del_ans, StringSplitOptions.None);
            for (int i2 = 0; i2 < num.Length; i2++)
            {
                meaning_word[i,i2] = num[i2];
                //Debug.Log(meaning_word[i, i2]);//iが単語の種類　i2が　0　単語名　1　単語の読み方　2　単語の意味
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void text_change(string ans)
    {
        Debug.Log(ans);
        for (int i = 0; i < text_meaning.Length; i++)
        {
            if (meaning_word[i, 0]==ans)
            {
                //Text_title.text = meaning_word[i, 0];
                Text.text = meaning_word[i, 2];
            }
        }

        //Text.text = text_main;
        //text_main = text_main.Remove(0, text_main.Length);
    }
}
