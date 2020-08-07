using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Text_test : MonoBehaviour
{
    public static int[] LineLenth;
    public static int ret;
    bool sw = false;
    string[] splitted;
    int Line = 0;

    private string loadText1;
    [SerializeField]
    private TextAsset textAsset;
    public GameObject prefab;
    GameObject[] obj;
    int count = 0;
    float text_x=0;

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
        SplitLengh(loadText1);
        string[] str = new string[splitted[Line].Length];
        string arr = splitted[Line];
        obj = new GameObject[splitted[Line].Length];
        for (int i = 0; i < splitted[Line].Length; i++)
        {
            str[i] = arr[i].ToString();
            if(splitted[Line].Length%2==0)//文字数が遇数なら
            {
                Debug.Log("偶数");
                text_x = transform.position.x + (((-(splitted[Line].Length / 2) + i) + 1.5f)/2);
                Debug.Log(text_x);
            }
            else//文字数が奇数なら
            {
                Debug.Log("奇数");
                if (i== (splitted[Line].Length-1) / 2)
                {
                    text_x = transform.position.x;
                    Debug.Log(transform.position.x);
                }
                else
                {
                    text_x = transform.position.x + ((-((splitted[Line].Length - 1) / 2) + i)/1.5f);
                }
            }
            obj[i] = Instantiate(prefab, new Vector2(text_x, transform.position.y), transform.rotation);
            obj[i].transform.parent = transform;
            obj[i].transform.localScale = new Vector3(1, 1, 1);//希望する値
            obj[i].GetComponent<Text>().text = str[i];
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(count < splitted[Line].Length)
            {
                obj[count].GetComponent<Text>().color = new Color(0, 0, 0, 0);
                count++;
            }
            else
            {
                count = 0;
                for (int i = 0; i < splitted[Line].Length; i++)
                {
                    Debug.Log("obj[i]:" + obj[i] + "i:" + i);
                    Destroy(obj[i]);
                }

                Line++;
                string[] str = new string[splitted[Line].Length];
                string arr = splitted[Line];
                obj = new GameObject[splitted[Line].Length];
                for (int i = 0; i < splitted[Line].Length; i++)
                {
                    str[i] = arr[i].ToString();
                    if (splitted[Line].Length % 2 == 0)//文字数が遇数なら
                    {
                        Debug.Log("偶数");
                        text_x = transform.position.x + (((-(splitted[Line].Length / 2) + i) + 1.5f) / 2);
                        Debug.Log(text_x);
                    }
                    else//文字数が奇数なら
                    {
                        Debug.Log("奇数");
                        if (i == (splitted[Line].Length - 1) / 2)
                        {
                            text_x = transform.position.x;
                            Debug.Log(transform.position.x);
                        }
                        else
                        {
                            text_x = transform.position.x + ((-((splitted[Line].Length - 1) / 2) + i) / 1.5f);
                        }
                    }
                    obj[i] = Instantiate(prefab, new Vector2(text_x, transform.position.y), transform.rotation);
                    obj[i].transform.parent = transform;
                    obj[i].transform.localScale = new Vector3(1, 1, 1);//希望する値
                    obj[i].GetComponent<Text>().text = str[i];
                }
            }
        }
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
    }
}
