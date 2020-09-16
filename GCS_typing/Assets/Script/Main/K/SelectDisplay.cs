using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectDisplay : MonoBehaviour//選択肢を表示するスクリプト
{
    private GetText GetText;
    private AllManeger AllManeger;
    private int number;
    private string[] Stext;
    private Text SelectText;
    // Start is called before the first frame update
    /*void Start()
    {
        GetText = GameObject.Find("GetText").GetComponent<GetText>();//ゲットテキストのゲットテキストスクリプトを取得
        AllManeger = this.GetComponent<AllManeger>();
        number = AllManeger.GetNumber();//ゲットテキストのゲットテキストスクリプトを取得
        Ptext = new string[10];
        Ptext = GetText.text;
        ProblemText = GameObject.Find("QuestionText").GetComponent<Text>();//問題文表示のテキストを取得
        ChangeProblemPresentation();//問題文の表示/入れ替えを行う
    }

    // Update is called once per frame
    void Update()
    {
        if (number != AllManeger.GetNumber()) ChangeProblemPresentation();//現在の問題文とAllManegerの問題の番号が一致しなかった場合
    }

    void ChangeProblemPresentation()//問題文の入れ替えを行う
    {
        ProblemText.text = "aaa<color=#00ffffff>AAA</color>";
    }*/
}
