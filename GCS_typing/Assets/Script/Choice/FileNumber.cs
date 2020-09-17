using UnityEngine;
using System.IO;
using System.Text;

public class FileNumber : MonoBehaviour//原稿の個数をnumに格納
{
    private int num;
    [SerializeField, Multiline(5)] private string[] Mstr;
    private string Dstr;

    public Manuscript[] M;
    public Dictionary[] D;
    public NewManuscript[] NM;

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
        num = files.Length;//numはファイルの数
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
        //clclassM(Mstr);
        clclassD(Dstr);//ファイルから持ってきた文字列をクラスに格納
        NewclclassM(Mstr);//ファイルから持ってきた文字列をクラスに格納

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
                        //Debug.Log("改行発見--" + i );
                        n++;
                        lp += 2;
                        //Debug.Log(n);
                    }
                }
                catch
                {
                    Debug.LogError(i + "個目の原稿がおかしいです\n無視します");
                    break;
                }
            }


            try
            {
                id = int.Parse(d);
            }
            catch (System.FormatException)
            {
                Debug.LogError("原稿内容がおかしいです。" + (i + 1) + "の原稿です。");
                t = "ERROR";
                id = 0;
                h = s[i];
            }
            M[i] = new Manuscript(t, id, h, g, r, this.GetComponent<GenerateDictionary>().Manuscripts[i]);

            /*if (i == 0)
            {
                Debug.Log(t);
                Debug.Log(d);
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
        int n = 0;
        count = 0;
        for(int i = 0;i < s.Length; i++)
        {
            if(s[i] == '\r' && s[i+1] == '\n')
            {
                count++;
            }
        }
        D = new Dictionary[count];
        Debug.Log(count);//辞書の単語数
        for (int i = 0; i < count; i++)
        {
            t = "";
            k = "";
            h = "";
            while (true)
            {
                if (s[n] == ' ' || s[n] == '　')
                {
                    n++;
                    break;
                }
                t += s[n];
                n++;
            }
            //Debug.Log(t);
            while (true)
            {
                if (s[n] == ' ' || s[n] == '　')
                {
                    n++;
                    break;
                }
                k += s[n];
                n++;
            }
            //Debug.Log(d);
            while (true)
            {
                if (s[n] == '\r' && s[n + 1] == '\n')
                {
                    n += 2;
                    break;
                }
                h += s[n];
                n++;
            }
            //Debug.Log(h);
            D[i] = new Dictionary(t, k, h);
            Debug.Log(D[i].GetWord() + " i = " + i);
        }

    }

    private void NewclclassM(string[] s)
    {
        NM = new NewManuscript[num];//ここはファイル数分クラスが生成される
        int n, Tnum,Qnum, Dnum, dnum;//現在の状態管理/本文の数/デブリの数/デブリの状態管理

        string t;//原稿タイトル   
        string d;//原稿難易度(文字列)
        int id;//原稿難易度(整数値)

        string[] text;//原稿本文（本文）
        string[,,] D;//デブリの格納（0 本文）（1 ひらがな）（2 ローマ字）



        for (int i = 0; i < num; i++)//各ファイルに関して処理、ファイル数分繰り返す
        {
            n = 0;Tnum = 0;Qnum = -3;Dnum = 0; dnum = 0; id = 0; t = "";d = "";//初期化
            text = new string[10];//初期化
            D = new string[0,0,0];//初期化
            for (int lp = 0; lp < text.Length; lp++)
            {
                text[lp] = "";

            }

            for (int lp = 0; lp < s[i].Length; lp++)//そのファイルに含まれる文字数繰り返す
            {
                //Debug.Log(s[i][lp] + "  文字数は" + lp);
                //if(s[i][lp] == '\r') Debug.Log("r発見" + "  文字数は" + lp);
                //if (s[i][lp] == '\n') Debug.Log("n発見" + "  文字数は" + lp);


                if (n == 0)
                {
                    if (s[i][lp] != '\r' && s[i][lp] != '\n' && s[i][lp] != ' ' && s[i][lp] != '　') t += s[i][lp];
                    Debug.Log(t + "  文字数は" + lp);
                }
                else if (n == 1)
                {
                    if (s[i][lp] != '\r' && s[i][lp] != '\n' && s[i][lp] != ' ' && s[i][lp] != '　') d += s[i][lp];
                    try
                    {
                        id = int.Parse(d);
                    }
                    catch (System.FormatException)
                    {
                        Debug.LogError("原稿内容がおかしいです。" + (i + 1) + "の原稿です。");
                    }
                    //Debug.Log(d + "  文字数は" + lp);
                }
                else if (n == 2)
                {
                    if (s[i][lp] != '\r' && s[i][lp] != '\n' && s[i][lp] != ' ' && s[i][lp] != '　') text[Tnum] += s[i][lp];
                    //Debug.Log(text[Tnum] + "  文字数は" + lp);
                    if (s[i][lp] == '\r' && s[i][lp+1] == '\n')
                    {
                        Tnum++;
                    }
                }
                else if (n >= 3)
                {
                    if (s[i][lp] == ' ' || s[i][lp] == '　')//半角、全角空白の場合
                    {
                        dnum++;
                    }
                    else if(s[i][lp] == '\r'&& s[i][lp + 1] == '\n')
                    {
                        dnum = 0;
                        Dnum++;
                        //Debug.Log("改行");
                    }
                    else
                    {
                        if (s[i][lp] != '\r' && s[i][lp] != '\n' &&s[i][lp] != ' ' && s[i][lp] != '　') D[Qnum,Dnum, dnum] += s[i][lp];
                        //Debug.Log(Qnum+""+Dnum+""+dnum);
                        //Debug.Log(D[Qnum, Dnum, 0] + " " + D[Qnum, Dnum, 1] + " " + D[Qnum, Dnum, 2] + "  文字数は" + lp);
                    }
                }

                try
                {
                    //Debug.Log("1文字目;"+s[i][lp] + "2文字目:" + s[i][lp+1]);
                    if (s[i][lp + 1] == '\r' && s[i][lp + 2] == '\n' && s[i][lp + 3] == '\r' && s[i][lp + 4] == '\n')//改行
                    {
                        n++;
                        lp += 4;
                        Qnum++;
                        Dnum = 0;
                        dnum = 0;
                        if (Qnum == 0)
                        {
                            D = new string[text.Length, id + 1, 3];//初期化
                            //Debug.Log("Dの初期化" + D.GetLength(0) + "" + D.GetLength(1) + "" + D.GetLength(2));
                            for (int llp = 0; llp < D.GetLength(0); llp++)
                            {
                                for (int lllp = 0; lllp < D.GetLength(1); lllp++)
                                {
                                    for (int llllp = 0; llllp < D.GetLength(2); llllp++)
                                    {
                                        D[llp, lllp, llllp] = "";
                                    }
                                }
                            }
                        }
                    }
                }
                catch
                {
                    if (lp + 1 == s[i].Length)
                    {
                        //Debug.Log("最後エラー：無視できます");
                    }
                    else
                    {
                        Debug.LogError("エラー：原因を確認してください");
                    }
                }
            }


            //NM[i] = new NewManuscript(Tnum,Dnum,t, id, text, D, this.GetComponent<GenerateDictionary>().Manuscripts[i]);
            //NM[i] = new NewManuscript(10, 30, t, id, text, D, this.GetComponent<GenerateDictionary>().Manuscripts[i]);
            NM[i] = new NewManuscript(t, id, text, D, this.GetComponent<GenerateDictionary>().Manuscripts[i]);
            //Debug.Log(t);
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
    private string meanings;//意味を改行して格納する変数

    public Dictionary(string word, string Hiragana, string meaning)
    {
        this.word = word;
        this.Hiragana = Hiragana;
        string M = meaning;
        StringTidy(M);
        //Debug.Log(meaning);
        //Debug.Log(meanings);
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
    public string GetMeanings()
    {
        return meanings;
    }
    private void StringTidy(string M)
    {
        this.meaning = "";
        this.meanings = "";
        for (int lp = 0; lp < M.Length; lp++)
        {
            if (M[lp] == '/')
            {
                this.meanings += "\r\n";
            }
            if (M[lp] != ' ' && M[lp] != '　' && M[lp] != '/')
            {
                this.meaning += M[lp];
                this.meanings += M[lp];
            }
        }
    }

}


public class NewManuscript
{
    private string title;//タイトルを格納する変数
    private int Difficulty;//難易度を格納する変数　2-4 それ以外は例外
    private string[] text;//本文を格納する変数
    private string[,,] debris;//デブリを格納する変数[問題番号,デブリの番号,0は単語1はひらがな2はローマ字]
    private GameObject Manuscripts;//原稿オブジェクトをGenerateDictionaryから持ってきて格納する変数



    public NewManuscript(string title, int Difficulty, string[] text, string[,,] debris, GameObject Manuscripts)
    {
        this.text = new string[text.Length];
        this.debris = new string[debris.GetLength(0), debris.GetLength(1), debris.GetLength(2)];
        this.title = title;
        this.Difficulty = Difficulty;
        this.text = text;
        this.debris = debris;
        RandomDebris();
        //Debugout();//デバック用
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
    public string[] GetText()
    {
        return text;
    }
    public string[,,] GetDebris()
    {
        return debris;
    }
    public GameObject GetManuscripts()
    {
        return Manuscripts;//本文を格納する変数
    }

    public void Debugout()
    {
        Debug.Log("タイトル:" + title);
        Debug.Log("難易度:" + Difficulty);
        for (int lp = 0; lp < text.Length; lp++) { Debug.Log(text[lp]); }
        for (int lp = 0; lp < debris.GetLength(0); lp++) { for (int c = 0; c < debris.GetLength(1); c++) { Debug.Log(debris[lp, c, 0]); } }
    }

    private void RandomDebris()
    {

        string[,,] D;
        D = new string[this.debris.GetLength(0), this.debris.GetLength(1), this.debris.GetLength(2)];//初期化

        int[] ary = new int[D.GetLength(1)];//デブリの数要素数を持つ配列を生成

        for (int lp = 0; lp < D.GetLength(1); lp++)
        {
            ary[lp] = lp;//要素１に０　２に１、、、デブリ数分格納
        }

        //Debug.Log(ary[0] + " " + ary[1]);

        for (int lp = 0; lp < D.GetLength(0); lp++)
        {
            C(ary);
            for (int llp = 0; llp < D.GetLength(1); llp++)
            {
                D[lp, llp, 0] = debris[lp, ary[llp], 0];
                D[lp, llp, 1] = debris[lp, ary[llp], 1];
                D[lp, llp, 2] = debris[lp, ary[llp], 2];
            }
        }
        debris = D;
    }

    private void C(int[] a)
    {
        for (int i = 0; i < a.Length; i++)
        {
            int cp = Random.Range(0, a.Length - 1);
            int num = a[i];
            a[i] = a[cp];
            a[cp] = num;
        }
    }
};