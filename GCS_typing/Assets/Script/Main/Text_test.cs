﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Text_test : MonoBehaviour
{
    public static int ret;
    bool sw = false;
    string[] splitted;
    string[] Rsplitted;
    public int Line = 0;

    private string loadText1;
    [SerializeField]
    private TextAsset textAsset;
    public GameObject prefab;
    GameObject[] obj;
    GameObject[] Transparent;
    int count = 0;
    float text_x=0;
    float Rtext_x = 0;

    public float width = 1.5f;
    public float Rwidth = 1.5f;
    public GetText GetText;
    public meaning meaning;

    public OnRisult OnRisult;
    public LoadText LoadText;
    [SerializeField]
    private Text meaning_title;
    [SerializeField]
    private Text meaning_text;

    public bool NextSpace=false;//追加。判定でおｋならtrue→処理後falseに---------------------------確認

    int score_Failure = 50;
    int score_time = 50;
    float time = 0;
    public int Failure = 0;
    public bool score_sw = false;

    // Start is called before the first frame update
    void Start()
    {
      //  loadText1 = GetText.text;
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
        SplitLengh(loadText1);
       // RSplitLengh(GetText.Rtext);
        string[] str = new string[splitted[Line].Length];
        string[] Rstr = new string[Rsplitted[Line].Length];
        string arr = splitted[Line];
        string Rarr = Rsplitted[Line];
        obj = new GameObject[splitted[Line].Length];
        Transparent = new GameObject[Rsplitted[Line].Length];
        for (int i = 0; i < splitted[Line].Length; i++)
        {
            str[i] = arr[i].ToString();
            if (splitted[Line].Length%2==0)//文字数が遇数なら
            {
                text_x = transform.position.x + ((i - (splitted[Line].Length / 2) + 0.5f) / width);
            }
            else//文字数が奇数なら
            {
                if (i== (splitted[Line].Length-1) / 2)
                {
                    text_x = transform.position.x;
                }
                else
                {
                    text_x = transform.position.x + ((-((splitted[Line].Length - 1) / 2) + i)/ width);
                }
            }
            obj[i] = Instantiate(prefab, new Vector2(text_x, transform.position.y), transform.rotation);
            obj[i].transform.parent = transform;
            obj[i].transform.localScale = new Vector3(1, 1, 1);//希望する値
            obj[i].GetComponent<Text>().text = str[i];
        }

        for (int i = 0; i < Rsplitted[Line].Length; i++)
        {
            Rstr[i] = Rarr[i].ToString();
            if (Rsplitted[Line].Length % 2 == 0)//文字数が遇数なら
            {
                Rtext_x = transform.position.x + ((i - (Rsplitted[Line].Length / 2) + 0.5f) / Rwidth);
            }
            else//文字数が奇数なら
            {
                if (i == (Rsplitted[Line].Length - 1) / 2)
                {
                    Rtext_x = transform.position.x;
                }
                else
                {
                    Rtext_x = transform.position.x + ((-((Rsplitted[Line].Length - 1) / 2) + i) / Rwidth);
                }
            }
            Transparent[i] = Instantiate(prefab, new Vector2(Rtext_x, transform.position.y - 0.75f), transform.rotation);
            Transparent[i].transform.parent = transform;
            Transparent[i].transform.localScale = new Vector3(1, 1, 1);//希望する値
            Transparent[i].GetComponent<Text>().text = Rstr[i];
        }

        /*
        if(meaning.meaning_line[meaning.Line]==0)
        {
            meaning_title.text = GetText.word[meaning.meaning_word[meaning.Line]];
            meaning_text.text = GetText.meaning[meaning.meaning_word[meaning.Line]];
            if (meaning_text.text.Length > 30)
            {
                meaning_text.text = meaning_text.text.Insert(30, "\n");
            }
        }
        meaning.Line++;
        */
    }

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;

        if (NextSpace)/////////////////////////一文字ずつ消えるところ、左の条件は最後には消すはず
        {
            try
            {
                if (count < Rsplitted[Line].Length - 1)
                {
                    //obj[count].GetComponent<Text>().color = new Color(0, 0, 0, 0);
                    Transparent[count].GetComponent<Text>().color = new Color(0, 0, 0, 0.25f);
                    count++;
                }
                else
                {
                    count = 0;
                    for (int i = 0; i < splitted[Line].Length; i++)
                    {
                        Destroy(obj[i]);
                    }
                    for (int i = 0; i < Rsplitted[Line].Length; i++)
                    {
                        Destroy(Transparent[i]);
                    }

                    Line++;
                    //Debug.Log("Line:" + Line + "ret:" + LoadText.ret);
                    //ここにクリアフラグ
                    if (Line == LoadText.ret)
                    {
                        OnRisult.flag = true;
                        //Debug.Log(OnRisult.flag);
                    }

                    text_move();

                    /*

                    if (meaning.meaning_line[meaning.Line] == Line)
                    {
                        meaning_title.text = GetText.word[meaning.meaning_word[meaning.Line]];
                        meaning_text.text = GetText.meaning[meaning.meaning_word[meaning.Line]];
                        if (meaning_text.text.Length > 30)
                        {
                            meaning_text.text = meaning_text.text.Insert(30, "\n");
                        }
                        meaning.Line++;
                    }*/


                    string[] str = new string[splitted[Line].Length];
                    string[] Rstr = new string[Rsplitted[Line].Length];
                    string arr = splitted[Line];
                    string Rarr = Rsplitted[Line];
                    obj = new GameObject[splitted[Line].Length];
                    Transparent = new GameObject[Rsplitted[Line].Length];
                    for (int i = 0; i < splitted[Line].Length; i++)
                    {
                        str[i] = arr[i].ToString();
                        if (splitted[Line].Length % 2 == 0)//文字数が遇数なら
                        {
                            text_x = transform.position.x + ((i - (splitted[Line].Length / 2) + 0.5f) / width);
                        }
                        else//文字数が奇数なら
                        {
                            if (i == (splitted[Line].Length - 1) / 2)
                            {
                                text_x = transform.position.x;
                            }
                            else
                            {
                                text_x = transform.position.x + ((-((splitted[Line].Length - 1) / 2) + i) / width);
                            }
                        }
                        obj[i] = Instantiate(prefab, new Vector2(text_x, transform.position.y), transform.rotation);
                        obj[i].transform.parent = transform;
                        obj[i].transform.localScale = new Vector3(1, 1, 1);//希望する値
                        obj[i].GetComponent<Text>().text = str[i];
                    }

                    for (int i = 0; i < Rsplitted[Line].Length; i++)
                    {
                        Rstr[i] = Rarr[i].ToString();
                        if (Rsplitted[Line].Length % 2 == 0)//文字数が遇数なら
                        {
                            Rtext_x = transform.position.x + ((i - (Rsplitted[Line].Length / 2) + 0.5f) / Rwidth);
                        }
                        else//文字数が奇数なら
                        {
                            if (i == (Rsplitted[Line].Length - 1) / 2)
                            {
                                Rtext_x = transform.position.x;
                            }
                            else
                            {
                                Rtext_x = transform.position.x + ((-((Rsplitted[Line].Length - 1) / 2) + i) / Rwidth);
                            }
                        }
                        Transparent[i] = Instantiate(prefab, new Vector2(Rtext_x, transform.position.y - 0.75f), transform.rotation);
                        Transparent[i].transform.parent = transform;
                        Transparent[i].transform.localScale = new Vector3(1, 1, 1);//希望する値
                        Transparent[i].GetComponent<Text>().text = Rstr[i];
                    }
                }
            }
            catch
            {
                Debug.LogError("配列参照外 おそらくnewで確保していないのが原因　scriptの呼び出しの順番かな？");
            }
            NextSpace = false;
        }

        if ((Failure % 5 == 0)&&(Failure!=0)&&(score_sw==false))
        {
            if (score_Failure > -1)
            {
                score_Failure--;
            }
            score_sw = true;
        }

        if (time >20)
        {
            if (score_time > -1)
            {
                score_time--;
            }
            Debug.Log(score_time);
            time = 0;
        }
    }


    void SplitLengh(string str)
    {
        string[] del = { "\r\n" };
        splitted = str.Split(del, StringSplitOptions.None);
    }

    void RSplitLengh(string str)
    {
        string[] del = { "\r\n" };
        Rsplitted = str.Split(del, StringSplitOptions.None);
    }

    public void text_move()
    {
        if ((LoadText.ret > 14)&&(LoadText.ret > 14 + Line))
        {
            LoadText.result = LoadText.result.Remove(0, LoadText.result.Length);
            for (int i = Line; i < 15 + Line; i++)
            {
                LoadText.result = String.Concat(LoadText.result, splitted[i]);
                LoadText.result = String.Concat(LoadText.result, "\n");
            }
            Debug.Log(LoadText.result);
            LoadText.dataText.text = LoadText.result;
        }
    }

    public int GetScore()
    {
        return (score_Failure + score_time) / 19;
    }
}
