using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Text_choice : MonoBehaviour
{
    [SerializeField]
    private TextAsset textAsset;
    private string loadText;
    string[] del = { "\r\n" };
    string[] splitted;

    string[,] str;

    int level = 3;


    // Start is called before the first frame update
    void Start()
    {
        loadText = textAsset.text;
        splitted = loadText.Split(del, StringSplitOptions.None);

        //splitted[0] とかは桐澤　splitted[1] とかは片倉


        for (int i = 0; i < level + 1; i++)
        {
            str = new string[level + 1,50];
        }




        for (int i = 0; i < level + 1; i++)
        {
            for (int i2 = 0; i2 < splitted[i].Length; i2++)
            {
                str[i, i2] = splitted[i2].ToString();
                Debug.Log(str[i, i2]);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
