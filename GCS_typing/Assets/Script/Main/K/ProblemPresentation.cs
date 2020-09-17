using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProblemPresentation : MonoBehaviour
{
    private AllManeger AllManeger;
    private int number;
    private string[] Ptext;
    private Text ProblemText;
    // Start is called before the first frame update
    void Start()
    {
        AllManeger = this.GetComponent<AllManeger>();
        number = AllManeger.GetNumber();//ゲットテキストのゲットテキストスクリプトを取得
        Ptext = new string[AllManeger.GetProblemNumber()];//問題数分のメモリ確保
        Ptext = AllManeger.GetProblemText();
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
        number = AllManeger.GetNumber();
        try
        {
            ProblemText.text = Ptext[number];
        }
        catch
        {
            ProblemText.text = "デバッグ<color=#00ffffff>中だってばよ</color>";
        }
    }
}
