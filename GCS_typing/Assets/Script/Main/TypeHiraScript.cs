using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeHiraScript : MonoBehaviour
{
    public Text_choice text_choice;//ガイドの色を変えるため
    public GetText GetText;//判定する日本語のファイル

    string[] NowStrings = new string[4];//0～3の選択肢の文字列がここに入る。

    int dummynum;//(ダミー含む)選択肢の数(1～4)

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void LoadText()
    {
        dummynum = GetText.debris.GetLength(1);//選択肢の総数(≒難易度)の取得

    }
}
