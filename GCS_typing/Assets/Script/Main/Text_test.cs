using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Text_test : MonoBehaviour
{
    [SerializeField] private Text text;
    public static int[] LineLenth;
    public static int ret;
    bool sw = false;
    string[] splitted;
    int Line = 0;

    private string loadText1;
    [SerializeField]
    private TextAsset textAsset;

    // Start is called before the first frame update
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
        text.text = loadText1;
        Debug.Log(loadText1);
        SplitLengh(text.text);
    }

    // Update is called once per frame
    void Update()
    {
        if (Line < ret + 1)
        {
            text.text = splitted[Line];
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Line++;
        }
        //Debug.Log(splitted[Line]);
    }


    void SplitLengh(string str)
    {
        string a = str;

        string before = str;
        string after = str.Replace("\n", "");
        ret = before.Length - after.Length;


        int[] Lenth = new int[ret + 1];
        LineLenth = new int[ret + 1];

        string[] del = { "\r\n" };
        splitted = str.Split(del, StringSplitOptions.None);

        //Debug.Log(ret);

        for (int i = 0; i < ret+1; i++)
        {
            //Debug.Log(splitted[i]);
        }
    }
}
