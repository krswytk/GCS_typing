using UnityEngine;
using System.Collections;
using System.IO;
using System.Text;

public class FileNumber : MonoBehaviour//原稿の個数をnumに格納
{
    private int num;
    [SerializeField, Multiline(5)] private string[] str;
    
    public Dictionary[] D;

    void Awake()
    {
        num = 0;
        ReadFiles();
    }


    /// <summary>
    /// 任意のフォルダ内のCSVファイル内容をすべて読み込む
    /// </summary>
    void ReadFiles()
    {
        string path = Application.dataPath + "/" + "text" + "/" + "Manuscript";
        string[] files = Directory.GetFiles(path, "*.txt", SearchOption.AllDirectories);
        str = new string[files.Length];
        for (int i = 0; i < files.Length; i++)
        {
            StreamReader sr = new StreamReader(files[i], Encoding.UTF8);
            str[i] = sr.ReadToEnd();
            sr.Close();
        }
        num = files.Length;
    }

    private void Start()
    {
        clclassD(str);
    }

    public int GetFN()
    {
        return num;
    }

    private void clclassD(string[] s)
    {
        D = new Dictionary[num];
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
            Debug.Log(t);
            Debug.Log(d);
            Debug.Log(h);
            D[i] = new Dictionary(t, int.Parse(d), h,this.GetComponent<GenerateDictionary>().Manuscripts[i]);
        }

    }
}

public class Dictionary
{
    private string title;//タイトルを格納する変数
    private int Difficulty;//難易度を格納する変数　1-5 それ以外は例外
    private string text;//本文を格納する変数
    private GameObject Manuscripts;//原稿オブジェクトをGenerateDictionaryから持ってきて格納する変数

    public Dictionary(string title, int Difficulty, string text, GameObject Manuscripts)
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
/*using UnityEngine;
using System.Collections;
using System.IO;
using System.Text;

public class FileNumber : MonoBehaviour//原稿の個数をnumに格納
{
    private int num;
    [SerializeField, Multiline(5)] private string[] str;
    
    public Dictionary[] D;

    void Awake()
    {
        num = 0;
        ReadFiles();
    }


    /// <summary>
    /// 任意のフォルダ内のCSVファイル内容をすべて読み込む
    /// </summary>
    void ReadFiles()
    {
        string path = Application.dataPath + "/" + "text" + "/" + "Manuscript";
        string[] files = Directory.GetFiles(path, "*.txt", SearchOption.AllDirectories);
        str = new string[files.Length];
        for (int i = 0; i < files.Length; i++)
        {
            StreamReader sr = new StreamReader(files[i], Encoding.UTF8);
            str[i] = sr.ReadToEnd();
            sr.Close();
        }
        num = files.Length;
    }

    private void Start()
    {
        clclassD(str);
    }

    public int GetFN()
    {
        return num;
    }

    private void clclassD(string[] s)
    {
        D = new Dictionary[num];
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
            Debug.Log(t);
            Debug.Log(d);
            Debug.Log(h);
            D[i] = new Dictionary(t, int.Parse(d), h,this.GetComponent<GenerateDictionary>().Manuscripts[i]);
        }

    }
}

public class Dictionary
{
    private string title;//タイトルを格納する変数
    private int Difficulty;//難易度を格納する変数　1-5 それ以外は例外
    private string text;//本文を格納する変数
    private GameObject Manuscripts;//原稿オブジェクトをGenerateDictionaryから持ってきて格納する変数

    public Dictionary(string title, int Difficulty, string text, GameObject Manuscripts)
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

*/
