using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Text_choice : MonoBehaviour
{
    [SerializeField]
    private TextAsset text;
    [SerializeField]
    private TextAsset roma;
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

    GameObject[] Robj;
    GameObject[] Robj2;
    GameObject[] Robj3;
    GameObject[] Robj4;

    int level = 3;
    float text_x = 0;
    float level_text_x = 0;

    int count = 0;

    public bool NextSpace = false;//追加。判定でおｋならtrue→処理後falseに---------------------------確認
    public bool NextSpace2 = false;//追加。判定でおｋならtrue→処理後falseに---------------------------確認
    public bool NextSpace3 = false;//追加。判定でおｋならtrue→処理後falseに---------------------------確認
    public bool NextSpace4 = false;//追加。判定でおｋならtrue→処理後falseに---------------------------確認



    // Start is called before the first frame update
    void Start()
    {
        text_Generate(text.text,0,false,2);
        text_Generate(roma.text,0.5f,true,5);

        //splitted[0] とかは桐澤　splitted[1] とかは片倉

    }

    // Update is called once per frame
    void Update()
    {
        if ((NextSpace)|| (Input.GetKeyDown(KeyCode.Space)))/////////////////////////一文字ずつ消えるところ、左の条件は最後には消すはず
        {
            if (count < Robj.Length - 1)
            {
                Robj[count].GetComponent<Text>().color = new Color(0, 0, 0, 0.25f);
                count++;
            }
            else
            {
                count = 0;
                text_Destroy();

                //text_Generate(text.text, 0, false, 2);
                //text_Generate(roma.text, 0.5f, true, 5);
            }
            NextSpace = false;
        }
    }

    void text_Generate(string Text,float y,bool sw,float width)//Text　読み込むテキスト,y　y座標,sw　ローマ字かどうか,width 文字幅
    {
        loadText = Text;
        splitted = loadText.Split(del, StringSplitOptions.None);
        for (int i = 0; i < level + 1; i++)
        {

            level_text_x = (-level / 2.0f + i) * 3;

            if (i == 0)
            {
                arr = splitted[i];
                str = new string[splitted[i].Length];

                if (sw == false)
                {
                    obj = new GameObject[splitted[i].Length];
                }
                else
                {
                    Robj = new GameObject[splitted[i].Length];
                }

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

                    if (sw == false)
                    {
                        obj[i2] = Instantiate(prefab, new Vector2(text_x + level_text_x, transform.position.y - y), transform.rotation);
                        obj[i2].transform.parent = transform;
                        obj[i2].transform.localScale = new Vector3(1, 1, 1);//希望する値
                        obj[i2].GetComponent<Text>().text = str[i2];
                    }else
                    {
                        Robj[i2] = Instantiate(prefab, new Vector2(text_x + level_text_x, transform.position.y - y), transform.rotation);
                        Robj[i2].transform.parent = transform;
                        Robj[i2].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);//希望する値
                        Robj[i2].GetComponent<Text>().text = str[i2];
                    }
                    
                }
            }
            if (i == 1)
            {
                arr2 = splitted[i];
                str2 = new string[splitted[i].Length];
                if (sw == false)
                {
                    obj2 = new GameObject[splitted[i].Length];
                }
                else
                {
                    Robj2 = new GameObject[splitted[i].Length];
                }
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
                    if (sw == false)
                    {
                        obj2[i2] = Instantiate(prefab, new Vector2(text_x + level_text_x, transform.position.y - y), transform.rotation);
                        obj2[i2].transform.parent = transform;
                        obj2[i2].transform.localScale = new Vector3(1, 1, 1);//希望する値
                        obj2[i2].GetComponent<Text>().text = str2[i2];
                    }
                    else
                    {
                        Robj2[i2] = Instantiate(prefab, new Vector2(text_x + level_text_x, transform.position.y - y), transform.rotation);
                        Robj2[i2].transform.parent = transform;
                        Robj2[i2].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);//希望する値
                        Robj2[i2].GetComponent<Text>().text = str2[i2];
                    }
                }
            }
            if (i == 2)
            {
                arr3 = splitted[i];
                str3 = new string[splitted[i].Length];
                if (sw == false)
                {
                    obj3 = new GameObject[splitted[i].Length];
                }
                else
                {
                    Robj3 = new GameObject[splitted[i].Length];
                }
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
                    if (sw == false)
                    {
                        obj3[i2] = Instantiate(prefab, new Vector2(text_x + level_text_x, transform.position.y - y), transform.rotation);
                        obj3[i2].transform.parent = transform;
                        obj3[i2].transform.localScale = new Vector3(1, 1, 1);//希望する値
                        obj3[i2].GetComponent<Text>().text = str3[i2];
                    }
                    else
                    {
                        Robj3[i2] = Instantiate(prefab, new Vector2(text_x + level_text_x, transform.position.y - y), transform.rotation);
                        Robj3[i2].transform.parent = transform;
                        Robj3[i2].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);//希望する値
                        Robj3[i2].GetComponent<Text>().text = str3[i2];
                    }
                }
            }
            if (i == 3)
            {
                arr4 = splitted[i];
                str4 = new string[splitted[i].Length];
                if (sw == false)
                {
                    obj4 = new GameObject[splitted[i].Length];
                }
                else
                {
                    Robj4 = new GameObject[splitted[i].Length];
                }
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
                    if (sw == false)
                    {
                        obj4[i2] = Instantiate(prefab, new Vector2(text_x + level_text_x, transform.position.y - y), transform.rotation);
                        obj4[i2].transform.parent = transform;
                        obj4[i2].transform.localScale = new Vector3(1, 1, 1);//希望する値
                        obj4[i2].GetComponent<Text>().text = str4[i2];
                    }
                    else
                    {
                        Robj4[i2] = Instantiate(prefab, new Vector2(text_x + level_text_x, transform.position.y - y), transform.rotation);
                        Robj4[i2].transform.parent = transform;
                        Robj4[i2].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);//希望する値
                        Robj4[i2].GetComponent<Text>().text = str4[i2];
                    }
                }
            }
        }
    }

    void text_Destroy()
    {
        for (int i = 0; i < obj.Length; i++)
        {
            Destroy(obj[i]);
        }
        for (int i = 0; i < obj2.Length; i++)
        {
            Destroy(obj2[i]);
        }
        for (int i = 0; i < obj3.Length; i++)
        {
            Destroy(obj3[i]);
        }
        for (int i = 0; i < obj4.Length; i++)
        {
            Destroy(obj4[i]);
        }

        for (int i = 0; i < Robj.Length; i++)
        {
            Destroy(Robj[i]);
        }
        for (int i = 0; i < Robj2.Length; i++)
        {
            Destroy(Robj2[i]);
        }
        for (int i = 0; i < Robj3.Length; i++)
        {
            Destroy(Robj3[i]);
        }
        for (int i = 0; i < Robj4.Length; i++)
        {
            Destroy(Robj4[i]);
        }
    }
}
