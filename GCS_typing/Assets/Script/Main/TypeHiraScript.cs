using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeHiraScript : MonoBehaviour
{
    public Text_choice text_choice;//ガイドの色を変えるため
    public GetText GetText;//判定する日本語のファイル

    string[] NowStrings = new string[4];//0～3の選択肢の文字列がここに入る。
    bool[] AllowInputs = new bool[4];//将来使う(かも)。入力判定をするかどうか。ほかの選択肢が入力されていたらfalseにしたいなー。
    int dummynum;//(ダミー含む)選択肢の数(1～4)

    void Start()
    {
        /*
         * 初期設定
         * ただ何度か処理を繰り返すので関数呼ぶくらい？
         */

    }

    void Update()
    {

    }

    void LoadText()
    {
        dummynum = GetText.debris.GetLength(1);//選択肢の総数(≒難易度)の取得
        for (int i = 0; i < dummynum; i++)
        {
            //AllowInputs=trueみたいな。後で追加
        }

        ///NowStringsに文字列を入れる
        for (int i = 0; i < dummynum; i++)
        {
            NowStrings[i] = GetText.debris[text_choice.problem_num, i, 1];
            //Debug.Log(j+"番目読み込み："+NowStrings[j]);
            //   KanaNums[i] = 0;
            //   SetChar(i, 0);
        }

    }

    //作る予定の関数たち

    /*dictionary
     * 
     *  {"あ", new string[1] {"a"}},
        {"い", new string[2] {"i", "yi"}},
        {"う", new string[3] {"u", "wu", "whu"}},
     * 
     * 
     */

}
