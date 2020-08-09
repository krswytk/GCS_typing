﻿using UnityEngine;
using System.Collections;
using System.IO;
using System.Text;

public class FileNumber : MonoBehaviour//原稿の個数をnumに格納
{
    private int num;
    [SerializeField, Multiline(5)] private string[] Mstr;
    private string Dstr;

    public Manuscript[] M;
    public Dictionary[] D;
    
    private string[][][] kiririn;//[原稿番号][行数][表示する単語]

    public int count;

    void Awake()
    {
        num = 0;
        ReadManuscriptFiles();
        ReadDictionaryFiles();//ファイル操作
        

    }


    /// <summary>
    /// 任意のフォルダ内のCSVファイル内容をすべて読み込む
    /// </summary>
    void ReadManuscriptFiles()
    {
        string path = Application.dataPath + "/" + "Text" + "/" + "Manuscript";
        string[] files = Directory.GetFiles(path, "*.txt", SearchOption.AllDirectories);
        Mstr = new string[files.Length];
        for (int i = 0; i < files.Length; i++)
        {
            StreamReader sr = new StreamReader(files[i], Encoding.UTF8);
            Mstr[i] = sr.ReadToEnd();
            sr.Close();
        }
        num = files.Length;
    }

    void ReadDictionaryFiles()
    {
        string[] str;
        string path = Application.dataPath + "/" + "Text";
        string[] files = Directory.GetFiles(path, "*.txt", SearchOption.AllDirectories);
        str = new string[files.Length];
        for (int i = 0; i < files.Length; i++)
        {
            StreamReader sr = new StreamReader(files[i], Encoding.UTF8);
            str[i] = sr.ReadToEnd();
            sr.Close();
        }
        Dstr = str[0];
        //Debug.Log(Dstr);
    }

    public void Start()
    {
        clclassM(Mstr);
        clclassD(Dstr);//ファイルから持ってきた文字列をクラスに格納

        //inDM();//単語と原稿を一致させる//未完成放置

        /*Debug.Log(M[0].GetTitle());
        Debug.Log(M[0].GetNumber());
        Debug.Log(M[0].GetText());  
        Debug.Log(D[0].GetTitle());
        Debug.Log(D[0].GetNumber());
        Debug.Log(D[0].GetText());*/
    }

    public int GetFN()
    {
        return num;
    }

    private void clclassM(string[] s)
    {
        M = new Manuscript[num];
        int n;

        string t;//原稿タイトル   
        string d;//原稿難易度(文字列)
        int id;//原稿難易度(整数値)

        string h;//原稿本文（本文）
        string g;//原稿本文（ひらがな）
        string r;//原稿本文（ローマ字）
        


        for (int i = 0; i < num; i++)
        {
            n = 0;
            t = "";
            d = "";
            h = "";
            g = "";
            r = "";

            for (int lp = 0; lp < s[i].Length; lp++)
            {
                //Debug.Log(s[i][lp] + "   " + lp);
                if (n == 0)
                {
                    if (s[i][lp] == ' ' || s[i][lp] == '　' || s[i][lp] == '\n')
                    {
                        n++;
                    }
                    else
                    {
                        t += s[i][lp];//タイトルを格納
                    }
                }
                else if (n == 1)
                {
                    if (s[i][lp] == ' ' || s[i][lp] == '　' || s[i][lp] == '\n')
                    {
                        n++;
                    }
                    else
                    {
                        d += s[i][lp];//難易度を格納
                    }
                }
                else if (n == 2)
                {
                    h += s[i][lp];//本文を格納
                }
                else if (n == 3)
                {
                    g += s[i][lp];//ひらがなを格納
                }
                else if (n == 4)
                {
                    r += s[i][lp];//ローマ字を格納
                }

                try
                {
                    if (s[i][lp] == '\n' && s[i][lp + 2] == '\n')
                    {
                        Debug.Log("改行発見②");
                        n++;
                        lp += 1;
                        //Debug.Log(n);
                    }
                }
                catch
                {
                    Debug.LogError(i+1 + "個目の原稿がおかしいです\n無視します");
                    break;
                }
            }


            try
            {
                id = int.Parse(d);
            }
            catch (System.FormatException)
            {
                Debug.Log("原稿内容がおかしいです");
                t = "ERROR";
                id = 0;
                h = s[i];
            }
            M[i] = new Manuscript(t, id, h, g, r, this.GetComponent<GenerateDictionary>().Manuscripts[i]);

            /*if (i == 0)
            {
                Debug.Log(t);
                Debug.Log(d);
                Debug.Log(nol);
                Debug.Log(h);
                Debug.Log(g);
                Debug.Log(r);
            }*/

        }

    }

    private void clclassD(string s)
    {
        string t;
        string k;
        string h;
        int n = -1;
        count = 0;
        for(int i = 0;i < s.Length; i++)
        {
            if(s[i] == '\n')
            {
                count++;
            }
        }
        D = new Dictionary[count];
        for (int i = 0; i < count; i++)
        {
            t = "";
            k = "";
            h = "";
            while (true)
            {
                n++;
                if (s[n] == ' ' || s[n] == '　' || s[n] == '\n')
                {
                    break;
                }
                t += s[n];
            }
            //Debug.Log(t);
            while (true)
            {
                n++;
                if (s[n] == ' ' || s[n] == '　' || s[n] == '\n')
                {
                    break;
                }
                k += s[n];
            }
            //Debug.Log(d);
            while (true)
            {
                n++;
                if (s[n] == ' ' || s[n] == '　' || s[n] == '\n')
                {
                    break;
                }
                h += s[n];
            }
            //Debug.Log(h);
            D[i] = new Dictionary(t, k, h);
        }

    }

  
}

public class Manuscript
{
    private string title;//タイトルを格納する変数
    private int Difficulty;//難易度を格納する変数　1-5 それ以外は例外
    private string text;//本文を格納する変数
    private string Htext;//本文(ひらがな）を格納する変数
    private string Rtext;//本文（ローマ字）を格納する変数
    private GameObject Manuscripts;//原稿オブジェクトをGenerateDictionaryから持ってきて格納する変数

    

    public Manuscript(string title, int Difficulty, string text, string Htext, string Rtext, GameObject Manuscripts)
    {
        this.title = title;
        this.Difficulty = Difficulty;
        this.text = text;
        this.Htext = Htext;
        this.Rtext = Rtext;
        this.Manuscripts = Manuscripts;
    }
    public Manuscript(string title, int Difficulty, string text)
    {
        this.title = title;
        this.Difficulty = Difficulty;
        this.text = text;
    }


    public string GetTitle()
    {
        return title;
    }
    public int GetNumber()
    {
        return Difficulty;
    }
    public string GetText()
    {
        return text;//本文を格納する変数
    }
    public string GetHtext()
    {
        return Htext;//本文を格納する変数
    }
    public string GetRtext()
    {
        return Rtext;//本文を格納する変数
    }
    public GameObject GetManuscripts()
    {
        return Manuscripts;//本文を格納する変数
    }

};

public class Dictionary
{
    private string word;//単語(漢字)を格納する変数
    private string Hiragana;//単語(ひらがな)を格納する変数
    private string meaning;//意味を格納する変数

    public Dictionary(string word, string Hiragana, string meaning)
    {
        this.word = word;
        this.Hiragana = Hiragana;
        this.meaning = meaning;
    }
    public string GetWord()
    {
        return word;
    }
    public string GetHiragana()
    {
        return Hiragana;
    }
    public string GetMeaning()
    {
        return meaning;
    }

}
