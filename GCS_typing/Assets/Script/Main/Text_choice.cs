using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Text_choice : MonoBehaviour
{
    [SerializeField]
    private TextAsset textAsset;
    [SerializeField]
    private GameObject prefab;
    private string loadText;
    string[] del = { "\r\n" };
    string[] splitted;

    string[] str;
    string[] str2;
    string[] str3;
    string[] str4;

    string arr;
    string arr2;
    string arr3;
    string arr4;

    GameObject[] obj;
    GameObject[] obj2;
    GameObject[] obj3;
    GameObject[] obj4;

    int level = 3;
    float text_x = 0;
    float level_text_x = 0;
    [SerializeField]
    private float width = 2.0f;


    // Start is called before the first frame update
    void Start()
    {
        loadText = textAsset.text;
        splitted = loadText.Split(del, StringSplitOptions.None);

        //splitted[0] とかは桐澤　splitted[1] とかは片倉


        for (int i = 0; i < level+1; i++)
        {

            level_text_x = (-level / 2.0f + i) * 3;

            Debug.Log(level_text_x);

            if (i == 0)
            {
                arr = splitted[i];
                str = new string[splitted[i].Length];
                obj = new GameObject[splitted[i].Length];
                for (int i2 = 0; i2 < splitted[i].Length; i2++)
                {
                    str[i2] = arr[i2].ToString();
                    if (splitted[i].Length % 2 == 0)//文字数が遇数なら
                    {
                        text_x = transform.position.x + ((i2 - (splitted[i].Length / 2) + 0.5f) / width);
                    }
                    else//文字数が奇数なら
                    {
                        if (i2 == (splitted[i].Length - 1) / 2)
                        {
                            text_x = transform.position.x;
                        }
                        else
                        {
                            text_x = transform.position.x + ((-((splitted[i].Length - 1) / 2) + i2) / width);
                        }
                    }
                    obj[i2] = Instantiate(prefab, new Vector2(text_x + level_text_x, transform.position.y), transform.rotation);
                    obj[i2].transform.parent = transform;
                    obj[i2].transform.localScale = new Vector3(1, 1, 1);//希望する値
                    obj[i2].GetComponent<Text>().text = str[i2];
                }
            }
            if (i == 1)
            {
                arr2 = splitted[i];
                str2 = new string[splitted[i].Length];
                obj2 = new GameObject[splitted[i].Length];
                for (int i2 = 0; i2 < splitted[i].Length; i2++)
                {
                    str2[i2] = arr2[i2].ToString();
                    if (splitted[i].Length % 2 == 0)//文字数が遇数なら
                    {
                        text_x = transform.position.x + ((i2 - (splitted[i].Length / 2) + 0.5f) / width);
                    }
                    else//文字数が奇数なら
                    {
                        if (i2 == (splitted[i].Length - 1) / 2)
                        {
                            text_x = transform.position.x;
                        }
                        else
                        {
                            text_x = transform.position.x + ((-((splitted[i].Length - 1) / 2) + i2) / width);
                        }
                    }
                    obj2[i2] = Instantiate(prefab, new Vector2(text_x + level_text_x, transform.position.y), transform.rotation);
                    obj2[i2].transform.parent = transform;
                    obj2[i2].transform.localScale = new Vector3(1, 1, 1);//希望する値
                    obj2[i2].GetComponent<Text>().text = str2[i2];
                }
            }
            if (i == 2)
            {
                arr3 = splitted[i];
                str3 = new string[splitted[i].Length];
                obj3 = new GameObject[splitted[i].Length];
                for (int i2 = 0; i2 < splitted[i].Length; i2++)
                {
                    str3[i2] = arr3[i2].ToString();
                    if (splitted[i].Length % 2 == 0)//文字数が遇数なら
                    {
                        text_x = transform.position.x + ((i2 - (splitted[i].Length / 2) + 0.5f) / width);
                    }
                    else//文字数が奇数なら
                    {
                        if (i2 == (splitted[i].Length - 1) / 2)
                        {
                            text_x = transform.position.x;
                        }
                        else
                        {
                            text_x = transform.position.x + ((-((splitted[i].Length - 1) / 2) + i2) / width);
                        }
                    }
                    obj3[i2] = Instantiate(prefab, new Vector2(text_x + level_text_x, transform.position.y), transform.rotation);
                    obj3[i2].transform.parent = transform;
                    obj3[i2].transform.localScale = new Vector3(1, 1, 1);//希望する値
                    obj3[i2].GetComponent<Text>().text = str3[i2];
                }
            }
            if (i == 3)
            {
                arr4 = splitted[i];
                str4 = new string[splitted[i].Length];
                obj4 = new GameObject[splitted[i].Length];
                for (int i2 = 0; i2 < splitted[i].Length; i2++)
                {
                    str4[i2] = arr4[i2].ToString();
                    if (splitted[i].Length % 2 == 0)//文字数が遇数なら
                    {
                        text_x = transform.position.x + ((i2 - (splitted[i].Length / 2) + 0.5f) / width);
                    }
                    else//文字数が奇数なら
                    {
                        if (i2 == (splitted[i].Length - 1) / 2)
                        {
                            text_x = transform.position.x;
                        }
                        else
                        {
                            text_x = transform.position.x + ((-((splitted[i].Length - 1) / 2) + i2) / width);
                        }
                    }
                    obj4[i2] = Instantiate(prefab, new Vector2(text_x + level_text_x, transform.position.y), transform.rotation);
                    obj4[i2].transform.parent = transform;
                    obj4[i2].transform.localScale = new Vector3(1, 1, 1);//希望する値
                    obj4[i2].GetComponent<Text>().text = str4[i2];
                }
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
