using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.UI;
using System;

public class LoadText : MonoBehaviour
{

    //　読み込んだテキストを出力するUIテキスト
    [SerializeField]
    private Text dataText;
    //　読む込むテキストが書き込まれている.txtファイル
    [SerializeField]
    private TextAsset textAsset;

    public static bool sw = false;


    //　テキストファイルから読み込んだデータ
    private string loadText1;
    //　Resourcesフォルダから直接テキストを読み込む
    private string loadText2;
    //　改行で分割して配列に入れる
    private string[] splitText1;
    //　改行で分割して配列に入れる
    private string[] splitText2;
    //　現在表示中テキスト1番号
    private int textNum1;
    //　現在表示中テキスト2番号
    private int textNum2;

    public GetText GetText;
    string[] splitted;

    void Start()
    {
        //GetText.text[0];
        loadText1 = GetText.text;
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

        /*
        string[] str = new string[loadText1.Length];
        int[] num = new int[loadText1.Length];
        for (int i = 0; i < GetText.word.Length; i++)
        {
            num[i] = loadText1.IndexOf(GetText.word[i]);
            Debug.Log(num[i]);
        }*/

        //int num[文字数][ヒットした順番に入れる]

        string before = GetText.text;
        string after = GetText.text.Replace("\n", "");
        int ret = before.Length - after.Length;

        string[] del = { "\r\n" };
        splitted = GetText.text.Split(del, StringSplitOptions.None);

        //Debug.Log(GetText.text);

        int[,] num = new int[splitted.Length, GetText.word.Length];
        for (int i = 0; i < splitted.Length; i++)
        {
            for (int i2 = 0; i2 < GetText.word.Length; i2++)
            {
                num[i,i2] = splitted[i].IndexOf(GetText.word[i2]);
                if(num[i, i2]>=0) Debug.Log("num:"+ num[i, i2]+" i_"+i+" i2_"+i2);//ここが0になった時のiが表示する段落
            }
        }

        //int num = GetText.text.IndexOf(GetText.word[1]);
        //Debug.Log(num);




        dataText.text = loadText1;
        //Debug.Log(loadText1);
    }

    void Update()
    {

        //　読み込んだテキストファイルの内容を表示

        /*
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("111111");
            Debug.Log(loadText1);

            dataText.text = loadText1;

            if (splitText1[textNum1] != "")
            {
                dataText.text = splitText1[textNum1];
                textNum1++;
                if (textNum1 >= splitText1.Length)
                {
                    textNum1 = 0;
                }
                Debug.Log(textNum1);
            }
            else
            {
                dataText.text = "";
                textNum1++;
            }
            //　Resourcesフォルダに配置したテキストファイルの内容を表示
        }
        else if (Input.GetButtonDown("Fire2"))
        {
            if (splitText2[textNum2] != "")
            {
                dataText.text = splitText2[textNum2];
                textNum2++;
                if (textNum2 >= splitText2.Length)
                {
                    textNum2 = 0;
                }
            }
            else
            {
                dataText.text = "";
                textNum2++;
            }
        }*/
    }

    void SplitLengh(string str)
    {
        string before = str;
        string after = str.Replace("\n", "");
        int ret = before.Length - after.Length;

        string[] del = { "\r\n" };
        splitted = str.Split(del, StringSplitOptions.None);
    }
}