using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllManeger : MonoBehaviour
{
    private int Number;//現在の問題番号0~9
    private int ProblemNumber;//問題数 基本は10
    private int Difficulty;//難易度を格納
    private GetText GetText;
    [SerializeField] private GameObject Basket;
    [SerializeField] private GameObject BasketBox;

    private string[] ProblemText;//問題文を格納
    private string[] Anser;//問題文の答えを格納


    // Start is called before the first frame update
    void Awake()//各種初期値の設定を行う
    {
        GetText = GameObject.Find("GetText").GetComponent<GetText>();//ゲットテキストのゲットテキストスクリプトを取得
        Number = 0;
    }

    void Start()//各種初期値の設定を行う
    {
        try
        {
            Difficulty = GetText.debris.GetLength(1);//難易度を格納
        }
        catch (NullReferenceException)
        {
            Difficulty = 3;//デバッグ用
        }
        ProblemNumber = GetText.text.Length;
        SetText();
    }
        // Update is called once per frame
        void Update()
    {
        
    }

    private void SetText()
    {
        string cpy;//一時的にコピーしておくための変数
        bool sw;
        ProblemText = new string[GetText.text.Length];//基本10かな
        Anser = new string[GetText.text.Length];

        for (int i = 0; i < ProblemText.Length; i++)
        {
            cpy = GetText.text[i];//まず問題文をコピー
            ProblemText[i] = "";//初期化
            Anser[i] = "";//初期化
            sw = true;
            for (int l = 0; l < cpy.Length; l++)//問題文の文字数分繰り返し
            {
                if(cpy[l] == '/')//もし文字が/だったら
                {
                    if (sw)
                    {
                        sw = false;
                        ProblemText[i] += "[  ]";
                    }
                    else sw = true;
                }
                else
                {
                    if (sw) ProblemText[i] += cpy[l];
                    else Anser[i] += cpy[l];
                }
            }
            //Debug.Log(ProblemText[i] + "  " + Anser[i]);
        }

    }

    public int GetNumber()
    {
        return Number;
    }
    public int GetProblemNumber()
    {
        return ProblemNumber;
    }
    public int GetDifficulty()
    {
        //Debug.Log("難易度送り込み" + Difficulty);
        return Difficulty;
    }
    public GameObject GetBasket()
    {
        return Basket;
    }
    public GameObject GetBasketBox()
    {
        return BasketBox;
    }
    public string[] GetProblemText()
    {
        return ProblemText;
    }
    public string[] GetAnser()
    {
        return Anser;
    }
}
