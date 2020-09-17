using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectDisplay : MonoBehaviour//選択肢を表示するスクリプト
{
    private GetText GetText;
    private AllManeger AllManeger;
    private SelectManeger SelectManeger;

    private int number;
    private string[] Stext;
    private Text SelectText;
    private GameObject[] Box;
    private Text[] Kanji;
    private Text[] Romaji;

    private int Difficulty;

    void Start()
    {
        GetText = GameObject.Find("GetText").GetComponent<GetText>();//ゲットテキストのゲットテキストスクリプトを取得
        AllManeger = this.GetComponent<AllManeger>();
        SelectManeger = this.GetComponent<SelectManeger>();
        number = AllManeger.GetNumber();//ゲットテキストのゲットテキストスクリプトを取得
        ChangeProblemPresentation();//問題文の表示/入れ替えを行う
        Difficulty = AllManeger.GetDifficulty();
        Box = new GameObject[Difficulty];
        Kanji = new Text[Difficulty];
        Romaji = new Text[Difficulty];
        Box = SelectManeger.GetBox();
        for (int i = 0; i < Difficulty; i++)
        {
            Kanji[i] = Box[i].transform.Find("Kanji").gameObject.GetComponent<Text>();
            Romaji[i] = Box[i].transform.Find("Romaji").gameObject.GetComponent<Text>();
        }

            KanjiC();
    }

    // Update is called once per frame
    void Update()
    {
        if (number != AllManeger.GetNumber()) KanjiC();//現在の問題文とAllManegerの問題の番号が一致しなかった場合
    }

    void ChangeProblemPresentation()//問題文の入れ替えを行う
    {
        //ProblemText.text = "aaa<color=#00ffffff>AAA</color>";
    }
    void KanjiC()
    {
        for(int i = 0;i < Difficulty; i++)
        {
            //Debug.Log("選択肢漢字表示");
            //Debug.Log(Box[i]);
            Kanji[i].text = GetText.debris[number,i,0];
            Romaji[i].text = GetText.debris[number, i, 2];
        }
    }
}
