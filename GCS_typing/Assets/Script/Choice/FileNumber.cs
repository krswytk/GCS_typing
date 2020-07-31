using UnityEngine;
using System.Collections;
using System.IO;
using System.Text;

public class FileNumber : MonoBehaviour//原稿の個数をnumに格納
{
    private int num;
    [SerializeField, Multiline(5)] private string[] str;

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
        num = files.Length - 1;
    }

    public int GetFN()
    {
        return num;
    }
}
