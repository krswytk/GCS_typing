using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// GetText.csの変数Htextを判定
/// </summary>
public class CheckTestScript : MonoBehaviour
{
    public Text_test text_Test;
    public Text_choice text_choice;
    public GetText GetText;//判定する日本語のファイル

    private string[] Strings = new string[4];
    private string[] NowStrings = new string[4];//0～3の選択肢がここに入る。
    private string[] NowChars = new string[4];//選択肢それぞれの今打つひらがな
    private string[] NextChars = new string[4];//それぞれの次の文字、拗音,促音のため。
    private string[,] NowKeys = new string[4, 4];//分解されたキーはこちら**charじゃないかも？

    private int[] KeyNums = new int[4];//それぞれのアルファベット何文字目
    private int[] KanaNums = new int[4];//NowStringsで,かな何文字目

    private int[] lineNums = new int[4];//
    private int[] lineNoms = new int[4];//

    //private string NowString;//今読み込んでる行。これを一文字ずつ↓に入れる＊＊＊選択肢が1行になったのでいらない。後で消すと思う。
    //private string NowChar;//今のひらがな(大文字英語も)一文字→これを分解する＊＊＊選択肢が1行になったのでいらない。後で消すと思う。
    //private string NextChar;//次の文字、拗音,促音のため。＊＊＊選択肢が1行になったのでいらない。後で消すと思う。
    private string PreKey = "";
    //private string[] NowKey = new string[4];//分解されたキーはこちら**charじゃないかも？
    //private int lineNum;//全体の行数＊＊＊選択肢が1行になったのでいらない。後で消すと思う。
    //private int lineNow;//今の行数＊＊＊選択肢が1行になったのでいらない。後で消すと思う。

    //private int KeyNum;//アルファベット何文字目
    //private int KanaNum;//NowStringでかな何文字目


    int dummynum;//選択肢の数、１～４



    void Start()
    {
        LoadText();

        //↓初期設定
        /*
        SetStrig(lineNow);
        SetChar(0);
        KeyNum = 0;
        KanaNum = 0;
        */
        //Debug.Log("Nowstring.lengs="+NowString.Length);
    }


    // Update is called once per frame
    void Update()
    {
        //入力があったり、初回
        if (Input.anyKeyDown)
        {
            //Debug.Log("入力：" + Input.inputString);//押されたキーがこれ

            if (Input.inputString != " " && Input.inputString != "\n" && !Input.GetMouseButton(0) && !Input.GetKeyDown(KeyCode.LeftShift))//エンターじゃないとか
            {

                //↓こいつ関数にして引数でそれぞれみたいなことをするのでは？
                KeyCheck(0);
                KeyCheck(1);
                KeyCheck(2);
                KeyCheck(3);
            }


            
            for (int j=0;j<4;j++)
            {
                if (NowKeys[j, KeyNums[j]] == "おわり")//次のひらがなに行きたい
                {
                    FinChar(j);
                }
            }

            //Debug.Log("次のキー：" + NowKeys[n,KeyNum]);

        }

        //
        //
        //

    }

    /// <summary>
    /// n番目の選択肢についての判定をしたい
    /// </summary>
    /// <param name="n"></param>
    void KeyCheck(int n)
    {
        if (NowKeys[n, KeyNums[n]] == Input.inputString)//ここで0～3分ける感じに
        {
            if (Input.inputString == "y" && NowChars[n] == "じ" && (NextChars[n] == "ゃ" || NextChars[n] == "ゅ" || NextChars[n] == "ょ"))//じゃとか
            {//「じ」であり、「ゃゅょ」であり、yが打たれたら内部だけ更新
                KeyNums[n]++;
                PreKey = Input.inputString;
            }
            else
            {
                text_Test.NextSpace = true;//
                text_choice.NextSpace[n] = true;
                KeyNums[n]++;
                PreKey = Input.inputString;
            }
            //Debug.Log("成功です");
            //ローマ字ならここで送信


        }
        else
        {
            //別表記。し、つ、ふ、じ、しゃ、ちゃ、じゃ
            switch (NowChars[n])
            {
                case "つ":
                    if (KeyNums[n] == 1 && Input.inputString == "s")//tsu
                    {
                        //Debug.Log("成功です");
                        //ローマ字ならここで送信
                        text_Test.NextSpace = true;
                        text_choice.NextSpace[n] = true;
                        NowKeys[n, 1] = "s";
                        NowKeys[n, 2] = "u";
                        NowKeys[n, 3] = "おわり";
                        KeyNums[n]++;
                        PreKey = Input.inputString;
                    }
                    break;
                case "ふ":
                    if (KeyNums[n] == 0 && Input.inputString == "f")//fu
                    {
                        //Debug.Log("成功です");
                        //ローマ字ならここで送信
                        text_Test.NextSpace = true;
                        text_choice.NextSpace[n] = true;
                        KeyNums[n]++;
                        PreKey = Input.inputString;
                    }
                    break;

                case "じ":
                    if (KeyNums[n] == 0 && Input.inputString == "j")//ji,jyaとかも先頭だけだからおｋ？
                    {
                        //Debug.Log("成功です");
                        //ローマ字ならここで送信
                        text_Test.NextSpace = true;
                        text_choice.NextSpace[n] = true;
                        KeyNums[n]++;
                        PreKey = Input.inputString;
                    }
                    if (KeyNums[n] == 1 && PreKey == "j")//ｊで売ってたら
                    {
                        if ((NextChars[n] == "ゃ" && Input.inputString == "a") || (NextChars[n] == "ゅ" && Input.inputString == "u") || (NextChars[n] == "ょ" && Input.inputString == "o"))//やゆよ
                        {
                            text_Test.NextSpace = true;
                            text_choice.NextSpace[n] = true;
                            KeyNums[n]++;
                            PreKey = Input.inputString;
                        }
                        text_Test.NextSpace = true;
                        text_choice.NextSpace[n] = true;
                        KeyNums[n]++;
                        PreKey = Input.inputString;
                    }
                    break;

                case "し":
                case "ち":
                    if (NowChars[n] == "ち" && KeyNums[n] == 0 && Input.inputString == "c")
                    {

                        KeyNums[n]++;
                        text_Test.NextSpace = true;
                        text_choice.NextSpace[n] = true;
                        PreKey = Input.inputString;
                    }
                    if (KeyNums[n] == 1 && Input.inputString == "h")//
                    {
                        //Debug.Log("成功です");
                        //ローマ字ならここで送信
                        //↓ガイドの仕方によってはここで送る。ガイド固定なのでここでは送らない。
                        //text_Test.NextSpace = true;
                        NowKeys[n, 1] = "h";
                        NowKeys[n, 2] = "i";
                        NowKeys[n, 3] = "おわり";
                        if (NextChars[n] == "ゃ" || NextChars[n] == "ゅ" || NextChars[n] == "ょ")//しゃなら
                        {
                            text_Test.NextSpace = true;
                            text_choice.NextSpace[n] = true;
                        }
                        KeyNums[n]++;
                        PreKey = Input.inputString;
                    }
                    //これで？
                    if (NextChars[n] == "ゃ")
                    {
                        NowKeys[n, 2] = "a";
                    }
                    else if (NextChars[n] == "ゅ")
                    {
                        NowKeys[n, 2] = "u";
                    }
                    else if (NextChars[n] == "ょ")
                    {
                        NowKeys[n, 2] = "o";
                    }
                    break;


                default:
                    Debug.Log("失敗ですこれ打って：" + NowKeys[n, KeyNums[n]]);
                    Debug.Log("keynum：" + KeyNums[n]);
                    break;
            }

            if (text_Test.NextSpace == false)
            {
                text_Test.Failure++;
                text_Test.score_sw = false;
            }


        }

    }

    /// <summary>
    /// 次のひらがなを読み込む関数。
    /// </summary>
    /// <param name="n"></param>
    void FinChar(int n)
    {
        KeyNums[n] = 0;
        KanaNums[n]++;
        //Debug.Log("kanaNum："+KanaNum);
        // Debug.Log("Length：" + NowString.Length);
        if (KanaNums[n] + 1 >= NowStrings[n].Length)//なんでプラス？
        {
            Debug.Log("行の最後まで来ました。次の行を読み込みます。");//そんなものはない
            //次の行を呼ぶ

            /*
            lineNows[n]++;
            if (lineNums[n] == lineNows[n])
            {
                //Debug.Log("終了です");
            }
            else
            {
                // Debug.Log("SetStringの呼び出し");
                SetStrig(lineNows[n]);
            }
            //Debug.Log("次の行→"+lineNow);
            */

        }
        else
        {
            SetChar(n, KanaNums[n]);
        }
    }

    /// <summary>
    /// 初期設定
    /// TextLinesに読み込み、Stringsに行で振り分け、行数をLinenumに
    /// </summary>
    void LoadText()
    {
        dummynum= GetText.debris.GetLength(1);
        //string TextLines = GetText.Htext;//ここ変更、4つになるんかな？で、配列にでも
        string TextLines1 = GetText.debris[1, 1, 1]; //1が日本語
        Debug.Log("今読み込んだやつ→" + TextLines1);//ok?
        //Strings = TextLines.Split('\n');
        //Debug.Log("一行目→" + Strings[0]);//ok?
        //lineNum = Strings.Length;//全部で何行だか入れる

        //ここで、NowStringsに代入
        for (int j=0;j<dummynum;j++)
        {
            NowStrings[j]= GetText.debris[1, j, 1];
            Debug.Log(j+"番目読み込み："+NowStrings[j]);
        }
    }



    /// <summary>
    /// NowStringの先頭からn文字目をNowCharに,
    /// n+1文字目があればNextCharに,なければ"行の最後"
    /// </summary>
    /// <param name="n"></param>
    void SetChar(int m, int n)
    {

        NowChars[m] = NowStrings[m].Substring(n, 1);//NowStringの先頭からn文字をaに(0スタート)
        //Debug.Log("NowString.Length="+ NowString.Length);
        //Debug.Log("n=" + n);
        if (n < NowStrings[m].Length - 2)//改行文字とかの関係
        {
            NextChars[m] = NowStrings[m].Substring(n + 1, 1);//次の文字がある
            Debug.Log("次の文字ある：" + NextChars[m]);
        }
        else
        {
            Debug.Log("次の文字ない");
            NextChars[m] = "行の最後";
        }


        //Debug.Log("Setchar関数で、NowCharに代入：" + NowChar);
        CharSplit(m, NowChars[m]);
        //pre.text = NowChar;
        //Debug.Log("今の文字→" + NowChar);
    }

    /// <summary>
    /// ひらがな一文字をローマ字に分解し、配列に入れる。！例外は見てないので別でやる必要あり！
    /// </summary>
    void CharSplit(int n, string kana)
    {
        //普通の文字の処理
        switch (kana)
        {
            case "あ":
                NowKeys[n, 0] = "a";
                NowKeys[n, 1] = "おわり";
                break;
            case "い":
                NowKeys[n, 0] = "i";
                NowKeys[n, 1] = "おわり";
                break;
            case "う":
                NowKeys[n, 0] = "u";
                NowKeys[n, 1] = "おわり";
                break;
            case "え":
                NowKeys[n, 0] = "e";
                NowKeys[n, 1] = "おわり";
                break;
            case "お":
                NowKeys[n, 0] = "o";
                NowKeys[n, 1] = "おわり";
                break;

            case "か":
                NowKeys[n, 0] = "k";
                NowKeys[n, 1] = "a";
                NowKeys[n, 2] = "おわり";
                break;
            case "き":
                NowKeys[n, 0] = "k";
                NowKeys[n, 1] = "i";
                NowKeys[n, 2] = "おわり";
                break;
            case "く":
                NowKeys[n, 0] = "k";
                NowKeys[n, 1] = "u";
                NowKeys[n, 2] = "おわり";
                break;
            case "け":
                NowKeys[n, 0] = "k";
                NowKeys[n, 1] = "e";
                NowKeys[n, 2] = "おわり";
                break;
            case "こ":
                NowKeys[n, 0] = "k";
                NowKeys[n, 1] = "o";
                NowKeys[n, 2] = "おわり";
                break;

            case "が":
                NowKeys[n, 0] = "g";
                NowKeys[n, 1] = "a";
                NowKeys[n, 2] = "おわり";
                break;
            case "ぎ":
                NowKeys[n, 0] = "g";
                NowKeys[n, 1] = "i";
                NowKeys[n, 2] = "おわり";
                break;
            case "ぐ":
                NowKeys[n, 0] = "g";
                NowKeys[n, 1] = "u";
                NowKeys[n, 2] = "おわり";
                break;
            case "げ":
                NowKeys[n, 0] = "g";
                NowKeys[n, 1] = "e";
                NowKeys[n, 2] = "おわり";
                break;
            case "ご":
                NowKeys[n, 0] = "g";
                NowKeys[n, 1] = "o";
                NowKeys[n, 2] = "おわり";
                break;

            case "さ":
                NowKeys[n, 0] = "s";
                NowKeys[n, 1] = "a";
                NowKeys[n, 2] = "おわり";
                break;
            case "し":
                NowKeys[n, 0] = "s";
                NowKeys[n, 1] = "i";
                NowKeys[n, 2] = "おわり";
                break;
            case "す":
                NowKeys[n, 0] = "s";
                NowKeys[n, 1] = "u";
                NowKeys[n, 2] = "おわり";
                break;
            case "せ":
                NowKeys[n, 0] = "s";
                NowKeys[n, 1] = "e";
                NowKeys[n, 2] = "おわり";
                break;
            case "そ":
                NowKeys[n, 0] = "s";
                NowKeys[n, 1] = "o";
                NowKeys[n, 2] = "おわり";
                break;

            case "ざ":
                NowKeys[n, 0] = "z";
                NowKeys[n, 1] = "a";
                NowKeys[n, 2] = "おわり";
                break;
            case "じ":
                NowKeys[n, 0] = "z";
                NowKeys[n, 1] = "i";
                NowKeys[n, 2] = "おわり";
                break;
            case "ず":
                NowKeys[n, 0] = "z";
                NowKeys[n, 1] = "u";
                NowKeys[n, 2] = "おわり";
                break;
            case "ぜ":
                NowKeys[n, 0] = "z";
                NowKeys[n, 1] = "e";
                NowKeys[n, 2] = "おわり";
                break;
            case "ぞ":
                NowKeys[n, 0] = "z";
                NowKeys[n, 1] = "o";
                NowKeys[n, 2] = "おわり";
                break;


            case "た":
                NowKeys[n, 0] = "t";
                NowKeys[n, 1] = "a";
                NowKeys[n, 2] = "おわり";
                break;
            case "ち":
                NowKeys[n, 0] = "t";
                NowKeys[n, 1] = "i";
                NowKeys[n, 2] = "おわり";
                break;
            case "つ":
                NowKeys[n, 0] = "t";
                NowKeys[n, 1] = "u";
                NowKeys[n, 2] = "おわり";
                break;
            case "て":
                NowKeys[n, 0] = "t";
                NowKeys[n, 1] = "e";
                NowKeys[n, 2] = "おわり";
                break;
            case "と":
                NowKeys[n, 0] = "t";
                NowKeys[n, 1] = "o";
                NowKeys[n, 2] = "おわり";
                break;

            case "だ":
                NowKeys[n, 0] = "d";
                NowKeys[n, 1] = "a";
                NowKeys[n, 2] = "おわり";
                break;
            case "ぢ":
                NowKeys[n, 0] = "d";
                NowKeys[n, 1] = "i";
                NowKeys[n, 2] = "おわり";
                break;
            case "づ":
                NowKeys[n, 0] = "d";
                NowKeys[n, 1] = "u";
                NowKeys[n, 2] = "おわり";
                break;
            case "で":
                NowKeys[n, 0] = "d";
                NowKeys[n, 1] = "e";
                NowKeys[n, 2] = "おわり";
                break;
            case "ど":
                NowKeys[n, 0] = "d";
                NowKeys[n, 1] = "o";
                NowKeys[n, 2] = "おわり";
                break;


            case "な":
                NowKeys[n, 0] = "n";
                NowKeys[n, 1] = "a";
                NowKeys[n, 2] = "おわり";
                break;
            case "に":
                NowKeys[n, 0] = "n";
                NowKeys[n, 1] = "i";
                NowKeys[n, 2] = "おわり";
                break;
            case "ぬ":
                NowKeys[n, 0] = "n";
                NowKeys[n, 1] = "u";
                NowKeys[n, 2] = "おわり";
                break;
            case "ね":
                NowKeys[n, 0] = "n";
                NowKeys[n, 1] = "e";
                NowKeys[n, 2] = "おわり";
                break;
            case "の":
                NowKeys[n, 0] = "n";
                NowKeys[n, 1] = "o";
                NowKeys[n, 2] = "おわり";
                break;

            case "は":
                NowKeys[n, 0] = "h";
                NowKeys[n, 1] = "a";
                NowKeys[n, 2] = "おわり";
                break;
            case "ひ":
                NowKeys[n, 0] = "h";
                NowKeys[n, 1] = "i";
                NowKeys[n, 2] = "おわり";
                break;
            case "ふ":
                NowKeys[n, 0] = "h";
                NowKeys[n, 1] = "u";
                NowKeys[n, 2] = "おわり";
                break;
            case "へ":
                NowKeys[n, 0] = "h";
                NowKeys[n, 1] = "e";
                NowKeys[n, 2] = "おわり";
                break;
            case "ほ":
                NowKeys[n, 0] = "h";
                NowKeys[n, 1] = "o";
                NowKeys[n, 2] = "おわり";
                break;

            case "ば":
                NowKeys[n, 0] = "b";
                NowKeys[n, 1] = "a";
                NowKeys[n, 2] = "おわり";
                break;
            case "び":
                NowKeys[n, 0] = "b";
                NowKeys[n, 1] = "i";
                NowKeys[n, 2] = "おわり";
                break;
            case "ぶ":
                NowKeys[n, 0] = "b";
                NowKeys[n, 1] = "u";
                NowKeys[n, 2] = "おわり";
                break;
            case "べ":
                NowKeys[n, 0] = "b";
                NowKeys[n, 1] = "e";
                NowKeys[n, 2] = "おわり";
                break;
            case "ぼ":
                NowKeys[n, 0] = "b";
                NowKeys[n, 1] = "o";
                NowKeys[n, 2] = "おわり";
                break;

            case "ぱ":
                NowKeys[n, 0] = "p";
                NowKeys[n, 1] = "a";
                NowKeys[n, 2] = "おわり";
                break;
            case "ぴ":
                NowKeys[n, 0] = "p";
                NowKeys[n, 1] = "i";
                NowKeys[n, 2] = "おわり";
                break;
            case "ぷ":
                NowKeys[n, 0] = "p";
                NowKeys[n, 1] = "u";
                NowKeys[n, 2] = "おわり";
                break;
            case "ぺ":
                NowKeys[n, 0] = "p";
                NowKeys[n, 1] = "e";
                NowKeys[n, 2] = "おわり";
                break;
            case "ぽ":
                NowKeys[n, 0] = "p";
                NowKeys[n, 1] = "o";
                NowKeys[n, 2] = "おわり";
                break;



            case "ま":
                NowKeys[n, 0] = "m";
                NowKeys[n, 1] = "a";
                NowKeys[n, 2] = "おわり";
                break;
            case "み":
                NowKeys[n, 0] = "m";
                NowKeys[n, 1] = "i";
                NowKeys[n, 2] = "おわり";
                break;
            case "む":
                NowKeys[n, 0] = "m";
                NowKeys[n, 1] = "u";
                NowKeys[n, 2] = "おわり";
                break;
            case "め":
                NowKeys[n, 0] = "m";
                NowKeys[n, 1] = "e";
                NowKeys[n, 2] = "おわり";
                break;
            case "も":
                NowKeys[n, 0] = "m";
                NowKeys[n, 1] = "o";
                NowKeys[n, 2] = "おわり";
                break;

            case "や":
                NowKeys[n, 0] = "y";
                NowKeys[n, 1] = "a";
                NowKeys[n, 2] = "おわり";
                break;
            case "ゆ":
                NowKeys[n, 0] = "y";
                NowKeys[n, 1] = "u";
                NowKeys[n, 2] = "おわり";
                break;
            case "よ":
                NowKeys[n, 0] = "y";
                NowKeys[n, 1] = "o";
                NowKeys[n, 2] = "おわり";
                break;

            case "ら":
                NowKeys[n, 0] = "r";
                NowKeys[n, 1] = "a";
                NowKeys[n, 2] = "おわり";
                break;
            case "り":
                NowKeys[n, 0] = "r";
                NowKeys[n, 1] = "i";
                NowKeys[n, 2] = "おわり";
                break;
            case "る":
                NowKeys[n, 0] = "r";
                NowKeys[n, 1] = "u";
                NowKeys[n, 2] = "おわり";
                break;
            case "れ":
                NowKeys[n, 0] = "r";
                NowKeys[n, 1] = "e";
                NowKeys[n, 2] = "おわり";
                break;
            case "ろ":
                NowKeys[n, 0] = "r";
                NowKeys[n, 1] = "o";
                NowKeys[n, 2] = "おわり";
                break;

            case "わ":
                NowKeys[n, 0] = "w";
                NowKeys[n, 1] = "a";
                NowKeys[n, 2] = "おわり";
                break;
            case "を":
                NowKeys[n, 0] = "w";
                NowKeys[n, 1] = "o";
                NowKeys[n, 2] = "おわり";
                break;
            case "ん":
                if (NextChars[n] == "行の最後" || NextChars[n] == "あ" || NextChars[n] == "い" || NextChars[n] == "う" || NextChars[n] == "え" || NextChars[n] == "お" ||
                    NextChars[n] == "な" || NextChars[n] == "に" || NextChars[n] == "ぬ" || NextChars[n] == "ね" || NextChars[n] == "の" ||
                    NextChars[n] == "や" || NextChars[n] == "ゆ" || NextChars[n] == "よ" || NextChars[n] == "。" || NextChars[n] == "、")
                {
                    Debug.Log("終わりのん");
                    NowKeys[n, 0] = "n";
                    NowKeys[n, 1] = "n";
                    NowKeys[n, 2] = "おわり";
                }
                else
                {
                    NowKeys[n, 0] = "n";
                    NowKeys[n, 1] = "おわり";
                }

                break;


            case "A":
            case "a":
                NowKeys[n, 0] = "a";
                NowKeys[n, 1] = "おわり";
                break;
            case "B":
                NowKeys[n, 0] = "b";
                NowKeys[n, 1] = "おわり";
                break;
            case "C":
                NowKeys[n, 0] = "c";
                NowKeys[n, 1] = "おわり";
                break;
            case "D":
                NowKeys[n, 0] = "d";
                NowKeys[n, 1] = "おわり";
                break;
            case "E":
                NowKeys[n, 0] = "e";
                NowKeys[n, 1] = "おわり";
                break;
            case "F":
                NowKeys[n, 0] = "f";
                NowKeys[n, 1] = "おわり";
                break;
            case "G":
                NowKeys[n, 0] = "g";
                NowKeys[n, 1] = "おわり";
                break;
            case "H":
                NowKeys[n, 0] = "h";
                NowKeys[n, 1] = "おわり";
                break;
            case "I":
                NowKeys[n, 0] = "i";
                NowKeys[n, 1] = "おわり";
                break;
            case "J":
                NowKeys[n, 0] = "j";
                NowKeys[n, 1] = "おわり";
                break;
            case "K":
                NowKeys[n, 0] = "k";
                NowKeys[n, 1] = "おわり";
                break;
            case "L":
                NowKeys[n, 0] = "l";
                NowKeys[n, 1] = "おわり";
                break;
            case "M":
                NowKeys[n, 0] = "m";
                NowKeys[n, 1] = "おわり";
                break;
            case "N":
                NowKeys[n, 0] = "n";
                NowKeys[n, 1] = "おわり";
                break;
            case "O":
                NowKeys[n, 0] = "o";
                NowKeys[n, 1] = "おわり";
                break;
            case "P":
                NowKeys[n, 0] = "p";
                NowKeys[n, 1] = "おわり";
                break;
            case "Q":
                NowKeys[n, 0] = "q";
                NowKeys[n, 1] = "おわり";
                break;
            case "R":
                NowKeys[n, 0] = "r";
                NowKeys[n, 1] = "おわり";
                break;
            case "S":
                NowKeys[n, 0] = "s";
                NowKeys[n, 1] = "おわり";
                break;
            case "T":
                NowKeys[n, 0] = "t";
                NowKeys[n, 1] = "おわり";
                break;
            case "U":
                NowKeys[n, 0] = "u";
                NowKeys[n, 1] = "おわり";
                break;
            case "V":
                NowKeys[n, 0] = "v";
                NowKeys[n, 1] = "おわり";
                break;
            case "W":
                NowKeys[n, 0] = "w";
                NowKeys[n, 1] = "おわり";
                break;
            case "X":
                NowKeys[n, 0] = "x";
                NowKeys[n, 1] = "おわり";
                break;
            case "Y":
                NowKeys[n, 0] = "y";
                NowKeys[n, 1] = "おわり";
                break;
            case "Z":
                NowKeys[n, 0] = "z";
                NowKeys[n, 1] = "おわり";
                break;

            case "１":
            case "1":
                NowKeys[n, 0] = "1";
                NowKeys[n, 1] = "おわり";
                break;
            case "２":
            case "2":
                NowKeys[n, 0] = "2";
                NowKeys[n, 1] = "おわり";
                break;
            case "３":
            case "3":
                NowKeys[n, 0] = "3";
                NowKeys[n, 1] = "おわり";
                break;
            case "４":
            case "4":
                NowKeys[n, 0] = "4";
                NowKeys[n, 1] = "おわり";
                break;
            case "５":
            case "5":
                NowKeys[n, 0] = "5";
                NowKeys[n, 1] = "おわり";
                break;
            case "６":
            case "6":
                NowKeys[n, 0] = "6";
                NowKeys[n, 1] = "おわり";
                break;
            case "７":
            case "7":
                NowKeys[n, 0] = "7";
                NowKeys[n, 1] = "おわり";
                break;
            case "８":
            case "8":
                NowKeys[n, 0] = "8";
                NowKeys[n, 1] = "おわり";
                break;
            case "９":
            case "9":
                NowKeys[n, 0] = "9";
                NowKeys[n, 1] = "おわり";
                break;
            case "０":
            case "0":
                NowKeys[n, 0] = "0";
                NowKeys[n, 1] = "おわり";
                break;

            //↓記号
            case "!":
                NowKeys[n, 0] = "!";
                NowKeys[n, 1] = "おわり";
                break;
            case "\"":
                NowKeys[n, 0] = "\"";
                NowKeys[n, 1] = "おわり";
                break;
            case "#":
                NowKeys[n, 0] = "#";
                NowKeys[n, 1] = "おわり";
                break;
            case "$":
                NowKeys[n, 0] = "$";
                NowKeys[n, 1] = "おわり";
                break;
            case "%":
                NowKeys[n, 0] = "%";
                NowKeys[n, 1] = "おわり";
                break;
            case "&":
                NowKeys[n, 0] = "&";
                NowKeys[n, 1] = "おわり";
                break;
            case "'":
                NowKeys[n, 0] = "'";
                NowKeys[n, 1] = "おわり";
                break;
            case "(":
                NowKeys[n, 0] = "(";
                NowKeys[n, 1] = "おわり";
                break;
            case ")":
                NowKeys[n, 0] = ")";
                NowKeys[n, 1] = "おわり";
                break;
            case "=":
                NowKeys[n, 0] = "=";
                NowKeys[n, 1] = "おわり";
                break;
            case "ー":
                NowKeys[n, 0] = "-";
                NowKeys[n, 1] = "おわり";
                break;

            case "。":
                NowKeys[n, 0] = ".";
                NowKeys[n, 1] = "おわり";
                break;
            case "、":
                NowKeys[n, 0] = ",";
                NowKeys[n, 1] = "おわり";
                break;

            //促音処理

            case "っ":
                //この関数をもう一度呼び出す

                CharSplit(n, NextChars[n]);//まず次の文字で呼び出す
                NowKeys[n, 1] = "おわり";//これで動く？
                break;




        }

        //↓ゃゅょ(拗音)の処理
        if (NextChars[n] == "ゃ" || NextChars[n] == "ゅ" || NextChars[n] == "ょ")
        {
            switch (NextChars[n])
            {
                case "ゃ":
                    NowKeys[n, 1] = "y";
                    NowKeys[n, 2] = "a";
                    NowKeys[n, 3] = "おわり";
                    KanaNums[n]++;//動いたわ
                    break;
                case "ゅ":
                    NowKeys[n, 1] = "y";
                    NowKeys[n, 2] = "u";
                    NowKeys[n, 3] = "おわり";
                    KanaNums[n]++;
                    break;
                case "ょ":
                    NowKeys[n, 1] = "y";
                    NowKeys[n, 2] = "o";
                    NowKeys[n, 3] = "おわり";
                    KanaNums[n]++;
                    break;
            }

        }

    }

    //以下修正しない------------------------------------------------------------------------

    /// <summary>
    /// 最初に"終わり"が現れるところを見てます。
    /// </summary>
    /// <returns></returns>
    int GetOwari(int n)
    {
        int i = 0;

        for (; NowKeys[n, i] != "おわり"; i++)
        {
            if (10 < i)
            {
                //(そんなことはないと思うが…)バグです
                Debug.Log("\"おわり\"が見つからないとかいうバグです");
                break;
            }
        }
        return i;
    }

    /// <summary>
    /// Nowstringに引数n行目をStrigs[]から入れる
    /// いらなくなった
    /// </summary>
    void SetStrig(int n)
    {
        /*
        NowString = Strings[n];
        //Debug.Log("Setstring関数\nNowStringに代入\"" + NowString + ".");
        KanaNum = 0;
        SetChar(0);
        */
    }

}
