using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckTestScript : MonoBehaviour
{
    public Text_test text_Test;
    public TextAsset TextF;//日本語テキストファイルがここに
    public GetText GetText;//日本語がとってこれるかも
    //public Text pre;//次を表示するとこ
    //public Text_test text_Test;

    private string[] Strings;
    private string NowString;//今読み込んでる行。これを一文字ずつ↓に入れる
    private string NowChar;//今のひらがな(大文字英語も)一文字→これを分解する
    private string NextChar;//次の文字、拗音,促音のため。
    private string PreKey="";//前に入力したキー
    private string[] NowKey = new string[4];//分解されたキーはこちら**charじゃないかも？
    private int lineNum;//全体の行数
    private int lineNow;//今の行数

    private int KeyNum;//アルファベット何文字目
    private int KanaNum;//NowStringでかな何文字目

    //private bool a = false;

    // Start is called before the first frame update
    void Start()
    {
        LoadText();

        //↓初期設定
        //lineNow = 0;//0行目はたいとるなら変更
        SetStrig(lineNow);
        SetChar(0);
        KeyNum = 0;
        KanaNum = 0;
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
                if (NowKey[KeyNum] == Input.inputString)
                {
                    if (Input.inputString == "y" && NowChar == "じ" && (NextChar == "ゃ" || NextChar == "ゅ" || NextChar == "ょ"))//じゃとか
                    {//「じ」であり、「ゃゅょ」であり、yが打たれたら内部だけ更新
                        KeyNum++;
                        PreKey = Input.inputString;
                    }
                    else
                    {
                        text_Test.NextSpace = true;
                        KeyNum++;
                        PreKey = Input.inputString;
                    }
                    //Debug.Log("成功です");
                    //ローマ字ならここで送信
                    

                }
                else
                {
                    //別表記。し、つ、ふ、じ、しゃ、ちゃ、じゃ
                    switch (NowChar)
                    {
                        case "つ":
                            if (KeyNum == 1 && Input.inputString == "s")//tsu
                            {
                                //Debug.Log("成功です");
                                //ローマ字ならここで送信
                                text_Test.NextSpace = true;
                                NowKey[1] = "s";
                                NowKey[2] = "u";
                                NowKey[3] = "おわり";
                                KeyNum++;
                                PreKey = Input.inputString;
                            }
                            break;
                        case "ふ":
                            if (KeyNum == 0 && Input.inputString == "f")//fu
                            {
                                //Debug.Log("成功です");
                                //ローマ字ならここで送信
                                text_Test.NextSpace = true;
                                KeyNum++;
                                PreKey = Input.inputString;
                            }
                            break;

                        case "じ":
                            if (KeyNum == 0 && Input.inputString == "j")//ji,jyaとかも先頭だけだからおｋ？
                            {
                                //Debug.Log("成功です");
                                //ローマ字ならここで送信
                                text_Test.NextSpace = true;
                                KeyNum++;
                                PreKey = Input.inputString;
                            }
                            if (KeyNum == 1&&PreKey=="j")//ｊで売ってたら
                            {
                                if ((NextChar=="ゃ"&&Input.inputString=="a")|| (NextChar == "ゅ"&&Input.inputString=="u")|| (NextChar == "ょ"&&Input.inputString=="o"))//やゆよ
                                {
                                    text_Test.NextSpace = true;
                                    KeyNum++;
                                    PreKey = Input.inputString;
                                }
                                text_Test.NextSpace = true;
                                KeyNum++;
                                PreKey = Input.inputString;
                            }
                            break;

                        case "し":
                        case "ち":
                            if (NowChar == "ち" && KeyNum == 0 && Input.inputString == "c")
                            {

                                KeyNum++;
                                text_Test.NextSpace = true;
                                PreKey = Input.inputString;
                            }
                            if (KeyNum == 1 && Input.inputString == "h")//
                            {
                                //Debug.Log("成功です");
                                //ローマ字ならここで送信
                                //↓ガイドの仕方によってはここで送る。ガイド固定なのでここでは送らない。
                                //text_Test.NextSpace = true;
                                NowKey[1] = "h";
                                NowKey[2] = "i";
                                NowKey[3] = "おわり";
                                if (NextChar == "ゃ"|| NextChar == "ゅ"|| NextChar == "ょ")//しゃなら
                                {
                                    text_Test.NextSpace = true;
                                }
                                KeyNum++;
                                PreKey = Input.inputString;
                            }
                            //これで？
                            if (NextChar == "ゃ")
                            {
                                NowKey[2] = "a";
                            }
                            else if (NextChar == "ゅ")
                            {
                                NowKey[2] = "u";
                            }
                            else if (NextChar == "ょ")
                            {
                                NowKey[2] = "o";
                            }
                            break;


                        default:
                            Debug.Log("失敗ですこれ打って：" + NowKey[KeyNum]);
                            Debug.Log("keynum：" + KeyNum);
                            break;
                    }

                    if (text_Test.NextSpace == false)
                    {
                        text_Test.Failure++;
                        text_Test.score_sw = false;
                    }


                }
            }


            if (NowKey[KeyNum] == "おわり")//次のひらがなに行きたい
            {
                //ひらがなならここで送信
                //text_Test.NextSpace = true;
                FinChar();
                //Debug.Log("次の文字：" + NowChar);

            }


            //Debug.Log("次のキー：" + NowKey[KeyNum]);
            
        }

        //
        //
        //
        
    }

    void FinChar()
    {
        KeyNum = 0;
        KanaNum++;
        //Debug.Log("kanaNum："+KanaNum);
        // Debug.Log("Length：" + NowString.Length);
        if (KanaNum + 1 >= NowString.Length)//なんでプラス？
        {
            Debug.Log("行の最後まで来ました。次の行を読み込みます。");
            //次の行を呼ぶ
            lineNow++;

            if (lineNum == lineNow)
            {
                //Debug.Log("終了です");
            }
            else
            {
                // Debug.Log("SetStringの呼び出し");
                SetStrig(lineNow);
            }
            //Debug.Log("次の行→"+lineNow);

        }
        else
        {
            SetChar(KanaNum);
        }
    }

    /// <summary>
    /// 初期設定
    /// TextLinesに読み込み、Stringsに行で振り分け、行数をLinenumに
    /// ひらがなの先頭を「#ひらがな原稿開始」で見ています。
    /// </summary>
    void LoadText()
    {
        string TextLines = GetText.Htext;
        Debug.Log("今読み込んだやつ→" + TextLines);//ok?
        Strings = TextLines.Split('\n');
        Debug.Log("一行目→" + Strings[0]);//ok?
        lineNum = Strings.Length;//全部で何行だか入れる

    }

    /// <summary>
    /// Nowstringに引数n行目をStrigs[]から入れる
    /// </summary>
    void SetStrig(int n)
    {
        NowString = Strings[n];
        //Debug.Log("Setstring関数\nNowStringに代入\"" + NowString + ".");
        KanaNum = 0;
        SetChar(0);
    }

    /// <summary>
    /// NowStringの先頭からn文字目をNowCharに,
    /// n+1文字目があればNextCharに,なければ"行の最後"
    /// </summary>
    /// <param name="n"></param>
    void SetChar(int n)
    {

        NowChar = NowString.Substring(n, 1);//NowStringの先頭からn文字をaに(0スタート)
        //Debug.Log("NowString.Length="+ NowString.Length);
        //Debug.Log("n=" + n);
        if (n < NowString.Length-2)//改行文字とかの関係
        {
            NextChar = NowString.Substring(n + 1, 1);//次の文字がある
            Debug.Log("次の文字ある：" + NextChar);
        }
        else
        {
            Debug.Log("次の文字ない" );
            NextChar = "行の最後";
        }


        //Debug.Log("Setchar関数で、NowCharに代入：" + NowChar);
        CharSplit(NowChar);
        //pre.text = NowChar;
        //Debug.Log("今の文字→" + NowChar);
    }

    /// <summary>
    /// ひらがな一文字をローマ字に分解し、配列に入れる。！例外は見てないので別でやる必要あり！
    /// </summary>
    void CharSplit(string kana)
    {
        //普通の文字の処理
        switch (kana)
        {
            case "あ":
                NowKey[0] = "a";
                NowKey[1] = "おわり";
                break;
            case "い":
                NowKey[0] = "i";
                NowKey[1] = "おわり";
                break;
            case "う":
                NowKey[0] = "u";
                NowKey[1] = "おわり";
                break;
            case "え":
                NowKey[0] = "e";
                NowKey[1] = "おわり";
                break;
            case "お":
                NowKey[0] = "o";
                NowKey[1] = "おわり";
                break;

            case "か":
                NowKey[0] = "k";
                NowKey[1] = "a";
                NowKey[2] = "おわり";
                break;
            case "き":
                NowKey[0] = "k";
                NowKey[1] = "i";
                NowKey[2] = "おわり";
                break;
            case "く":
                NowKey[0] = "k";
                NowKey[1] = "u";
                NowKey[2] = "おわり";
                break;
            case "け":
                NowKey[0] = "k";
                NowKey[1] = "e";
                NowKey[2] = "おわり";
                break;
            case "こ":
                NowKey[0] = "k";
                NowKey[1] = "o";
                NowKey[2] = "おわり";
                break;

            case "が":
                NowKey[0] = "g";
                NowKey[1] = "a";
                NowKey[2] = "おわり";
                break;
            case "ぎ":
                NowKey[0] = "g";
                NowKey[1] = "i";
                NowKey[2] = "おわり";
                break;
            case "ぐ":
                NowKey[0] = "g";
                NowKey[1] = "u";
                NowKey[2] = "おわり";
                break;
            case "げ":
                NowKey[0] = "g";
                NowKey[1] = "e";
                NowKey[2] = "おわり";
                break;
            case "ご":
                NowKey[0] = "g";
                NowKey[1] = "o";
                NowKey[2] = "おわり";
                break;

            case "さ":
                NowKey[0] = "s";
                NowKey[1] = "a";
                NowKey[2] = "おわり";
                break;
            case "し":
                NowKey[0] = "s";
                NowKey[1] = "i";
                NowKey[2] = "おわり";
                break;
            case "す":
                NowKey[0] = "s";
                NowKey[1] = "u";
                NowKey[2] = "おわり";
                break;
            case "せ":
                NowKey[0] = "s";
                NowKey[1] = "e";
                NowKey[2] = "おわり";
                break;
            case "そ":
                NowKey[0] = "s";
                NowKey[1] = "o";
                NowKey[2] = "おわり";
                break;

            case "ざ":
                NowKey[0] = "z";
                NowKey[1] = "a";
                NowKey[2] = "おわり";
                break;
            case "じ":
                NowKey[0] = "z";
                NowKey[1] = "i";
                NowKey[2] = "おわり";
                break;
            case "ず":
                NowKey[0] = "z";
                NowKey[1] = "u";
                NowKey[2] = "おわり";
                break;
            case "ぜ":
                NowKey[0] = "z";
                NowKey[1] = "e";
                NowKey[2] = "おわり";
                break;
            case "ぞ":
                NowKey[0] = "z";
                NowKey[1] = "o";
                NowKey[2] = "おわり";
                break;


            case "た":
                NowKey[0] = "t";
                NowKey[1] = "a";
                NowKey[2] = "おわり";
                break;
            case "ち":
                NowKey[0] = "t";
                NowKey[1] = "i";
                NowKey[2] = "おわり";
                break;
            case "つ":
                NowKey[0] = "t";
                NowKey[1] = "u";
                NowKey[2] = "おわり";
                break;
            case "て":
                NowKey[0] = "t";
                NowKey[1] = "e";
                NowKey[2] = "おわり";
                break;
            case "と":
                NowKey[0] = "t";
                NowKey[1] = "o";
                NowKey[2] = "おわり";
                break;

            case "だ":
                NowKey[0] = "d";
                NowKey[1] = "a";
                NowKey[2] = "おわり";
                break;
            case "ぢ":
                NowKey[0] = "d";
                NowKey[1] = "i";
                NowKey[2] = "おわり";
                break;
            case "づ":
                NowKey[0] = "d";
                NowKey[1] = "u";
                NowKey[2] = "おわり";
                break;
            case "で":
                NowKey[0] = "d";
                NowKey[1] = "e";
                NowKey[2] = "おわり";
                break;
            case "ど":
                NowKey[0] = "d";
                NowKey[1] = "o";
                NowKey[2] = "おわり";
                break;


            case "な":
                NowKey[0] = "n";
                NowKey[1] = "a";
                NowKey[2] = "おわり";
                break;
            case "に":
                NowKey[0] = "n";
                NowKey[1] = "i";
                NowKey[2] = "おわり";
                break;
            case "ぬ":
                NowKey[0] = "n";
                NowKey[1] = "u";
                NowKey[2] = "おわり";
                break;
            case "ね":
                NowKey[0] = "n";
                NowKey[1] = "e";
                NowKey[2] = "おわり";
                break;
            case "の":
                NowKey[0] = "n";
                NowKey[1] = "o";
                NowKey[2] = "おわり";
                break;

            case "は":
                NowKey[0] = "h";
                NowKey[1] = "a";
                NowKey[2] = "おわり";
                break;
            case "ひ":
                NowKey[0] = "h";
                NowKey[1] = "i";
                NowKey[2] = "おわり";
                break;
            case "ふ":
                NowKey[0] = "h";
                NowKey[1] = "u";
                NowKey[2] = "おわり";
                break;
            case "へ":
                NowKey[0] = "h";
                NowKey[1] = "e";
                NowKey[2] = "おわり";
                break;
            case "ほ":
                NowKey[0] = "h";
                NowKey[1] = "o";
                NowKey[2] = "おわり";
                break;

            case "ば":
                NowKey[0] = "b";
                NowKey[1] = "a";
                NowKey[2] = "おわり";
                break;
            case "び":
                NowKey[0] = "b";
                NowKey[1] = "i";
                NowKey[2] = "おわり";
                break;
            case "ぶ":
                NowKey[0] = "b";
                NowKey[1] = "u";
                NowKey[2] = "おわり";
                break;
            case "べ":
                NowKey[0] = "b";
                NowKey[1] = "e";
                NowKey[2] = "おわり";
                break;
            case "ぼ":
                NowKey[0] = "b";
                NowKey[1] = "o";
                NowKey[2] = "おわり";
                break;

            case "ぱ":
                NowKey[0] = "p";
                NowKey[1] = "a";
                NowKey[2] = "おわり";
                break;
            case "ぴ":
                NowKey[0] = "p";
                NowKey[1] = "i";
                NowKey[2] = "おわり";
                break;
            case "ぷ":
                NowKey[0] = "p";
                NowKey[1] = "u";
                NowKey[2] = "おわり";
                break;
            case "ぺ":
                NowKey[0] = "p";
                NowKey[1] = "e";
                NowKey[2] = "おわり";
                break;
            case "ぽ":
                NowKey[0] = "p";
                NowKey[1] = "o";
                NowKey[2] = "おわり";
                break;



            case "ま":
                NowKey[0] = "m";
                NowKey[1] = "a";
                NowKey[2] = "おわり";
                break;
            case "み":
                NowKey[0] = "m";
                NowKey[1] = "i";
                NowKey[2] = "おわり";
                break;
            case "む":
                NowKey[0] = "m";
                NowKey[1] = "u";
                NowKey[2] = "おわり";
                break;
            case "め":
                NowKey[0] = "m";
                NowKey[1] = "e";
                NowKey[2] = "おわり";
                break;
            case "も":
                NowKey[0] = "m";
                NowKey[1] = "o";
                NowKey[2] = "おわり";
                break;

            case "や":
                NowKey[0] = "y";
                NowKey[1] = "a";
                NowKey[2] = "おわり";
                break;
            case "ゆ":
                NowKey[0] = "y";
                NowKey[1] = "u";
                NowKey[2] = "おわり";
                break;
            case "よ":
                NowKey[0] = "y";
                NowKey[1] = "o";
                NowKey[2] = "おわり";
                break;

            case "ら":
                NowKey[0] = "r";
                NowKey[1] = "a";
                NowKey[2] = "おわり";
                break;
            case "り":
                NowKey[0] = "r";
                NowKey[1] = "i";
                NowKey[2] = "おわり";
                break;
            case "る":
                NowKey[0] = "r";
                NowKey[1] = "u";
                NowKey[2] = "おわり";
                break;
            case "れ":
                NowKey[0] = "r";
                NowKey[1] = "e";
                NowKey[2] = "おわり";
                break;
            case "ろ":
                NowKey[0] = "r";
                NowKey[1] = "o";
                NowKey[2] = "おわり";
                break;

            case "わ":
                NowKey[0] = "w";
                NowKey[1] = "a";
                NowKey[2] = "おわり";
                break;
            case "を":
                NowKey[0] = "w";
                NowKey[1] = "o";
                NowKey[2] = "おわり";
                break;
            case "ん":
                if (NextChar=="行の最後")
                {
                    Debug.Log("終わりのん");
                    NowKey[0] = "n";
                    NowKey[1] = "n";
                    NowKey[2] = "おわり";
                }
                else
                {
                    NowKey[0] = "n";
                    NowKey[1] = "おわり";
                }
                
                break;


            case "A":
                NowKey[0] = "a";
                NowKey[1] = "おわり";
                break;
            case "B":
                NowKey[0] = "b";
                NowKey[1] = "おわり";
                break;
            case "C":
                NowKey[0] = "c";
                NowKey[1] = "おわり";
                break;
            case "D":
                NowKey[0] = "d";
                NowKey[1] = "おわり";
                break;
            case "E":
                NowKey[0] = "e";
                NowKey[1] = "おわり";
                break;
            case "F":
                NowKey[0] = "f";
                NowKey[1] = "おわり";
                break;
            case "G":
                NowKey[0] = "g";
                NowKey[1] = "おわり";
                break;
            case "H":
                NowKey[0] = "h";
                NowKey[1] = "おわり";
                break;
            case "I":
                NowKey[0] = "i";
                NowKey[1] = "おわり";
                break;
            case "J":
                NowKey[0] = "j";
                NowKey[1] = "おわり";
                break;
            case "K":
                NowKey[0] = "k";
                NowKey[1] = "おわり";
                break;
            case "L":
                NowKey[0] = "l";
                NowKey[1] = "おわり";
                break;
            case "M":
                NowKey[0] = "m";
                NowKey[1] = "おわり";
                break;
            case "N":
                NowKey[0] = "n";
                NowKey[1] = "おわり";
                break;
            case "O":
                NowKey[0] = "o";
                NowKey[1] = "おわり";
                break;
            case "P":
                NowKey[0] = "p";
                NowKey[1] = "おわり";
                break;
            case "Q":
                NowKey[0] = "q";
                NowKey[1] = "おわり";
                break;
            case "R":
                NowKey[0] = "r";
                NowKey[1] = "おわり";
                break;
            case "S":
                NowKey[0] = "s";
                NowKey[1] = "おわり";
                break;
            case "T":
                NowKey[0] = "t";
                NowKey[1] = "おわり";
                break;
            case "U":
                NowKey[0] = "u";
                NowKey[1] = "おわり";
                break;
            case "V":
                NowKey[0] = "v";
                NowKey[1] = "おわり";
                break;
            case "W":
                NowKey[0] = "w";
                NowKey[1] = "おわり";
                break;
            case "X":
                NowKey[0] = "x";
                NowKey[1] = "おわり";
                break;
            case "Y":
                NowKey[0] = "y";
                NowKey[1] = "おわり";
                break;
            case "Z":
                NowKey[0] = "z";
                NowKey[1] = "おわり";
                break;

            case "１":
            case "1":
                NowKey[0] = "1";
                NowKey[1] = "おわり";
                break;
            case "２":
            case "2":
                NowKey[0] = "2";
                NowKey[1] = "おわり";
                break;
            case "３":
            case "3":
                NowKey[0] = "3";
                NowKey[1] = "おわり";
                break;
            case "４":
            case "4":
                NowKey[0] = "4";
                NowKey[1] = "おわり";
                break;
            case "５":
            case "5":
                NowKey[0] = "5";
                NowKey[1] = "おわり";
                break;
            case "６":
            case "6":
                NowKey[0] = "6";
                NowKey[1] = "おわり";
                break;
            case "７":
            case "7":
                NowKey[0] = "7";
                NowKey[1] = "おわり";
                break;
            case "８":
            case "8":
                NowKey[0] = "8";
                NowKey[1] = "おわり";
                break;
            case "９":
            case "9":
                NowKey[0] = "9";
                NowKey[1] = "おわり";
                break;
            case "０":
            case "0":
                NowKey[0] = "0";
                NowKey[1] = "おわり";
                break;

            //↓記号
            case "!":
                NowKey[0] = "!";
                NowKey[1] = "おわり";
                break;
            case "\"":
                NowKey[0] = "\"";
                NowKey[1] = "おわり";
                break;
            case "#":
                NowKey[0] = "#";
                NowKey[1] = "おわり";
                break;
            case "$":
                NowKey[0] = "$";
                NowKey[1] = "おわり";
                break;
            case "%":
                NowKey[0] = "%";
                NowKey[1] = "おわり";
                break;
            case "&":
                NowKey[0] = "&";
                NowKey[1] = "おわり";
                break;
            case "'":
                NowKey[0] = "'";
                NowKey[1] = "おわり";
                break;
            case "(":
                NowKey[0] = "(";
                NowKey[1] = "おわり";
                break;
            case ")":
                NowKey[0] = ")";
                NowKey[1] = "おわり";
                break;
            case "=":
                NowKey[0] = "=";
                NowKey[1] = "おわり";
                break;
            case "ー":
                NowKey[0] = "-";
                NowKey[1] = "おわり";
                break;

            case "。":
                NowKey[0] = ".";
                NowKey[1] = "おわり";
                break;
            case "、":
                NowKey[0] = ",";
                NowKey[1] = "おわり";
                break;

            //促音処理

            case "っ":
                //この関数をもう一度呼び出す

                CharSplit(NextChar);//まず次の文字で呼び出す
                NowKey[1] = "おわり";//これで動く？
                break;




        }

        //↓ゃゅょ(拗音)の処理
        if (NextChar == "ゃ" || NextChar == "ゅ" || NextChar == "ょ")
        {
            switch (NextChar)
            {
                case "ゃ":
                    NowKey[1] = "y";
                    NowKey[2] = "a";
                    NowKey[3] = "おわり";
                    KanaNum++;//動いたわ
                    break;
                case "ゅ":
                    NowKey[1] = "y";
                    NowKey[2] = "u";
                    NowKey[3] = "おわり";
                    KanaNum++;
                    break;
                case "ょ":
                    NowKey[1] = "y";
                    NowKey[2] = "o";
                    NowKey[3] = "おわり";
                    KanaNum++;
                    break;
            }

        }

    }

    /// <summary>
    /// 最初に"終わり"が現れるところを見てます。
    /// </summary>
    /// <returns></returns>
    int GetOwari()
    {
        int i = 0;

        for (; NowKey[i] != "おわり"; i++)
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

    public bool GetNextSpace()//これ何？いる？
    {
        return true;
    }
}
