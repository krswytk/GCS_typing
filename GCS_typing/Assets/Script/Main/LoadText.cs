using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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

    void Start()
    {
        loadText1 = textAsset.text;
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
}