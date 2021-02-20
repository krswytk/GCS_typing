using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContentDisplay : MonoBehaviour
{
    private Text text;
    private FileNumber FN;
    private Onturn OT;
    GameObject Manuscript;
    int num;
    string[] maintext;
    string[] Rtext;

    // Start is called before the first frame update
    void Start()
    {
        text = this.GetComponent<Text>();
        Manuscript = GameObject.Find("TestManuscripS");
        FN = Manuscript.GetComponent<FileNumber>();
        OT = Manuscript.GetComponent<Onturn>();

        maintext = new string[FN.GetFN()];//原稿数の配列を確保
        Rtext = new string[FN.GetFN()];//原稿数の配列を確保
        for (int i = 0; i < maintext.Length; i++)
        {
            maintext[i] = "";
            for (int l = 0; l< FN.M[i].GetText().Length; l++)
            {
                if (FN.M[i].GetText()[l] != '\n')
                {
                    maintext[i] += FN.M[i].GetText()[l];//原稿クラスにアクセスしてテキストをコピー
                }
            }
            Rtext[i] = "";
            for (int l = 0; l < maintext[i].Length; l++)
            {
                Rtext[i] += maintext[i][l];
                if (maintext[i][l] == '。')
                {
                    Rtext[i] += "\n";
                }
            }
        }
        num = 0;
        CT();
    }
    
    public void CT()
    {
        Debug.Log("num : " + num);
        num = OT.GetNum();
        Debug.Log("num : " + num);
        text.text = Rtext[num];
    }
}
