using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class LoadText : MonoBehaviour
{

    //　読み込んだテキストを出力するUIテキスト
    [SerializeField]
    public Text dataText;
    //　読む込むテキストが書き込まれている.txtファイル
    [SerializeField]
    private TextAsset textAsset;

    public static bool sw = false;

    private string loadText1; //　テキストファイルから読み込んだデータ
    private string[] splitText1;//　改行で分割して配列に入れる
    private string[] splitText2;//　改行で分割して配列に入れる


    public GetText GetText;
    public Text_test Text_test;
    public meaning meaning;
    public string[] splitted;
    public string result;
    public int[,] num;
    public int ret;

    void Start()
    {
        /*
        //GetText.text[0];
        //loadText1 = GetText.text;
        loadText1 = loadText1.Replace("1", "１");
        loadText1 = loadText1.Replace("2", "２");
        loadText1 = loadText1.Replace("3", "３");
        loadText1 = loadText1.Replace("4", "４");
        loadText1 = loadText1.Replace("5", "５");
        loadText1 = loadText1.Replace("6", "６");
        loadText1 = loadText1.Replace("7", "７");
        loadText1 = loadText1.Replace("8", "８");
        loadText1 = loadText1.Replace("9", "９");
        loadText1 = loadText1.Replace("0", "０");

       // string before = GetText.text;
       // string after = GetText.text.Replace("\n", "");
      //  ret = before.Length - after.Length;

        string[] del = { "\r\n" };
      //  splitted = GetText.text.Split(del, StringSplitOptions.None);

        num = new int[splitted.Length, GetText.word.Length];

        meaning.meaning_line = new int[splitted.Length];
        meaning.meaning_word = new int[GetText.word.Length];

        for (int i = 0; i < splitted.Length; i++)
        {
            for (int i2 = 0; i2 < GetText.word.Length; i2++)
            {
                num[i,i2] = splitted[i].IndexOf(GetText.word[i2]);
                if (num[i, i2] >= 0)
                {
                    //Debug.Log("num:" + num[i, i2] + " i_" + i + " i2_" + i2);
                    //iが表示する段落
                    //i2が表示する配列番号
                    meaning.meaning_line[meaning.Add_num] = i;
                    meaning.meaning_word[meaning.Add_num] = i2;
                    meaning.Add_num++;
                }
            }
        }
        if(ret>14)
        {
            for (int i = 0; i < 15; i++)
            {
                result = String.Concat(result, splitted[i]);
                result = String.Concat(result, "\n");
            }
        }else
        {
            result = loadText1;
        }

        //int num = GetText.text.IndexOf(GetText.word[1]);
        //Debug.Log(num);




        dataText.text = result;
        //Debug.Log(loadText1);*/
    }

    void Update()
    {

    }

    public void text_move()
    {
        if (ret > 14)
        {
            result= result.Remove(0, result.Length);
            for (int i = Text_test.Line; i < 15 + Text_test.Line; i++)
            {
                result = String.Concat(result, splitted[i]);
            }
            Debug.Log(result);
            dataText.text = result;
        }
    }
}