using UnityEngine;
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

    void Awake()
    {
        num = 0;
        ReadManuscriptFiles();
        ReadDictionaryFiles();
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

    private void Start()
    {
        clclassM(Mstr);
        clclassD(Dstr);
    }

    public int GetFN()
    {
        return num;
    }

    private void clclassM(string[] s)
    {
        M = new Manuscript[num];
        int n;
        string t;
        string d;
        string h;


        for (int i = 0; i < num; i++)
        {
            n = 0;
            t = "";
            d = "";
            h = "";
            int id;

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
                else
                {
                    h += s[i][lp];//本文を格納
                }
            }
            //Debug.Log(t);
            //Debug.Log(d);
            //Debug.Log(h);

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

            M[i] = new Manuscript(t, id, h,this.GetComponent<GenerateDictionary>().Manuscripts[i]);
        }

    }

    private void clclassD(string s)
    {
        string t;
        string k;
        string h;
        int n = -1;
        int count = 0;
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
    private GameObject Manuscripts;//原稿オブジェクトをGenerateDictionaryから持ってきて格納する変数

    public Manuscript(string title, int Difficulty, string text, GameObject Manuscripts)
    {
        this.title = title;
        this.Difficulty = Difficulty;
        this.text = text;
        this.Manuscripts = Manuscripts;
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
    public string GetTitle()
    {
        return word;
    }
    public string GetNumber()
    {
        return Hiragana;
    }
    public string GetText()
    {
        return meaning;
    }

}
