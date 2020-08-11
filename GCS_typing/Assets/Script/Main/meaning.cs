using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class meaning : MonoBehaviour
{
    [SerializeField] private Text dataText;
    [SerializeField] private TextAsset textAsset;
    private string loadText1;
    public GetText GetText;
    public LoadText LoadText;
    public Text_test Text_test;
    public int[,] num;
    public int[] meaning_line;
    public int[] meaning_word;

    public int Add_num = 0;


    void Start()
    {
        for (int i = 0; i < Add_num; i++)
        {

        }


        loadText1 = textAsset.text;

        if(loadText1.Length>42)
            loadText1 = loadText1.Insert(42, "\n");
        dataText.text = loadText1;
    }

    // Update is called once per frame
    void Update()
    {
        /*
         
        texttestのほうでラインを変更した時に
         lineとここのmeaning_lineが一致すれば
         ここのテキストをgettext.word[meaning_word[meaning_lineの()内と同じ数字]]
         に変更する
        




         */
    }
}
