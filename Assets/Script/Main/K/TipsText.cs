using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipsText : MonoBehaviour
{
    private GetText GetText;
    private AllManeger AllManeger;
    private Text TipsT;
    private int number;

    private string[] a;
    private string t;
    // Start is called before the first frame update
    void Start()
    {
        AllManeger = this.GetComponent<AllManeger>();
        GetText = GameObject.Find("GetText").GetComponent<GetText>();//ゲットテキストのゲットテキストスクリプトを取得
        number = AllManeger.GetNumber();//ゲットテキストのゲットテキストスクリプトを取得
        a = new string[AllManeger.GetProblemNumber()];//問題数分のメモリ確保
        TipsT = GameObject.Find("TipsText").GetComponent<Text>();
        a = AllManeger.GetAnser();
        Debug.Log("test");
        CT();
    }

    // Update is called once per frame
    void Update()
    {
        if (number != AllManeger.GetNumber()) CT();//現在の問題文とAllManegerの問題の番号が一致しなかった場合
    }

    private void CT()
    {
        number = AllManeger.GetNumber();
        Debug.Log(a[number]);
        for (int i = 0;i < GetText.word.Length; i++)
        {
            if (a[number] == GetText.word[i])
            {
                t = GetText.meaning[i];
                break;
            }
        }
        TipsT.text = t;
    }
}
