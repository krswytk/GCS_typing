using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class Text_choice : MonoBehaviour
{
    [SerializeField]
    private TextAsset text;
    [SerializeField]
    private TextAsset roma;
    [SerializeField]
    private GameObject prefab;

    string[] del = { "\r\n" };
    string[] del_ans = { "/" };

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

    int level = 0;
    float text_x = 0;
    float level_text_x = 0;

    int Answer = 1;

    int count = 0;
    int count2 = 0;
    int count3 = 0;
    int count4 = 0;

    public int problem_num = 0;
    int clear_num = 0;

    public bool[] NextSpace;//追加。判定でおｋならtrue→処理後falseに---------------------------確認

    public GetText GetText;
    public main_text main_text;
    public meaning meaning;
    public CheckTestScript CheckTestScript;
    public OnRisult OnRisult;



    // Start is called before the first frame update
    void Start()
    {
        NextSpace = new bool[4];
        for (int i = 0; i < NextSpace.Length; i++)
        {
            NextSpace[i] = false;
        }
        //[問題番号0-9  ,  回答0-3  ,  0に単語 1にひらがな　2にローマ字]
        //Debug.Log(GetText.debris.GetLength(1));
        level = GetText.debris.GetLength(1) - 1;
        clear_num = GetText.debris.GetLength(0);
        answer_check();
        text_Generate(text.text,0,false,5, problem_num);
        text_Generate(roma.text,0.5f,true,5, problem_num);
    }

    // Update is called once per frame
    void Update()
    {

        if (NextSpace[0])/////////////////////////一文字ずつ消えるところ、左の条件は最後には消すはず
        {
            text_update();
            NextSpace[0] = false;
        }

        if (NextSpace[1])/////////////////////////一文字ずつ消えるところ、左の条件は最後には消すはず
        {
            text_update2();
            NextSpace[1] = false;
        }

        if (NextSpace[2])/////////////////////////一文字ずつ消えるところ、左の条件は最後には消すはず
        {
            text_update3();
            NextSpace[2] = false;
        }

        if (NextSpace[3])/////////////////////////一文字ずつ消えるところ、左の条件は最後には消すはず
        {
            text_update4();
            NextSpace[3] = false;
        }
    }

    void answer_check()
    {
        string[] ans = GetText.text[problem_num].Split(del_ans, StringSplitOptions.None);

        for (int i = 0; i < level+1; i++)
        {
            if (GetText.debris[problem_num, i, 0]==ans[1])
            {
                Answer = i;
            }
        }
        meaning.text_change(ans[1]);
    }

    void text_Generate(string Text,float y,bool sw,float width, int problem_num)//Text　読み込むテキスト,y　y座標,sw　ローマ字かどうか,width 文字幅
    {
        for (int i = 0; i < level+1; i++)
        {

            level_text_x = (-level / 2.0f + i) * 5;

            if (i == 0)
            {
                if (sw == false)
                {
                    arr = GetText.debris[problem_num, i, 0];
                    obj = new GameObject[arr.Length];
                }
                else
                {
                    arr = GetText.debris[problem_num, i, 2];
                    Robj = new GameObject[arr.Length];
                }

                str = new string[arr.Length];

                for (int i2 = 0; i2 < arr.Length; i2++)
                {
                    str[i2] = arr[i2].ToString();
                    if (arr.Length % 2 == 0)//文字数が遇数なら
                    {
                        text_x = transform.position.x + ((i2 - (arr.Length / 2) + 0.5f) / width);
                    }
                    else//文字数が奇数なら
                    {
                        if (i2 == (arr.Length - 1) / 2)
                        {
                            text_x = transform.position.x;
                        }
                        else
                        {
                            text_x = transform.position.x + ((-((arr.Length - 1) / 2) + i2) / width);
                        }
                    }

                    if (sw == false)
                    {
                        obj[i2] = Instantiate(prefab, new Vector2(text_x + level_text_x, transform.position.y - y), transform.rotation);
                        obj[i2].transform.parent = transform;
                        obj[i2].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);//希望する値
                        obj[i2].GetComponent<Text>().text = str[i2];
                    }else
                    {
                        Robj[i2] = Instantiate(prefab, new Vector2(text_x + level_text_x, transform.position.y - y), transform.rotation);
                        Robj[i2].transform.parent = transform;
                        Robj[i2].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);//希望する値
                        Robj[i2].GetComponent<Text>().text = str[i2];
                        Robj[i2].GetComponent<Text>().color = new Color(1, 0, 0, 1);
                    }
                    
                }
            }
            if (i == 1)
            {
                if (sw == false)
                {
                    arr2 = GetText.debris[problem_num, i, 0];
                    obj2 = new GameObject[arr2.Length];
                }
                else
                {
                    arr2 = GetText.debris[problem_num, i, 2];
                    Robj2 = new GameObject[arr2.Length];
                }

                str2 = new string[arr2.Length];

                for (int i2 = 0; i2 < arr2.Length; i2++)
                {
                    str2[i2] = arr2[i2].ToString();
                    if (arr2.Length % 2 == 0)//文字数が遇数なら
                    {
                        text_x = transform.position.x + ((i2 - (arr2.Length / 2) + 0.5f) / width);
                    }
                    else//文字数が奇数なら
                    {
                        if (i2 == (arr2.Length - 1) / 2)
                        {
                            text_x = transform.position.x;
                        }
                        else
                        {
                            text_x = transform.position.x + ((-((arr2.Length - 1) / 2) + i2) / width);
                        }
                    }
                    if (sw == false)
                    {
                        obj2[i2] = Instantiate(prefab, new Vector2(text_x + level_text_x, transform.position.y - y), transform.rotation);
                        obj2[i2].transform.parent = transform;
                        obj2[i2].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);//希望する値
                        obj2[i2].GetComponent<Text>().text = str2[i2];
                    }
                    else
                    {
                        Robj2[i2] = Instantiate(prefab, new Vector2(text_x + level_text_x, transform.position.y - y), transform.rotation);
                        Robj2[i2].transform.parent = transform;
                        Robj2[i2].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);//希望する値
                        Robj2[i2].GetComponent<Text>().text = str2[i2];
                        Robj2[i2].GetComponent<Text>().color = new Color(1, 0, 0, 1);
                    }
                }
            }
            if (i == 2)
            {
                if (sw == false)
                {
                    arr3 = GetText.debris[problem_num, i, 0];
                    obj3 = new GameObject[arr3.Length];
                }
                else
                {
                    arr3 = GetText.debris[problem_num, i, 2];
                    Robj3 = new GameObject[arr3.Length];
                }

                str3 = new string[arr3.Length];

                for (int i2 = 0; i2 < arr3.Length; i2++)
                {
                    str3[i2] = arr3[i2].ToString();
                    if (arr3.Length % 2 == 0)//文字数が遇数なら
                    {
                        text_x = transform.position.x + ((i2 - (arr3.Length / 2) + 0.5f) / width);
                    }
                    else//文字数が奇数なら
                    {
                        if (i2 == (arr3.Length - 1) / 2)
                        {
                            text_x = transform.position.x;
                        }
                        else
                        {
                            text_x = transform.position.x + ((-((arr3.Length - 1) / 2) + i2) / width);
                        }
                    }
                    if (sw == false)
                    {
                        obj3[i2] = Instantiate(prefab, new Vector2(text_x + level_text_x, transform.position.y - y), transform.rotation);
                        obj3[i2].transform.parent = transform;
                        obj3[i2].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);//希望する値
                        obj3[i2].GetComponent<Text>().text = str3[i2];
                    }
                    else
                    {
                        Robj3[i2] = Instantiate(prefab, new Vector2(text_x + level_text_x, transform.position.y - y), transform.rotation);
                        Robj3[i2].transform.parent = transform;
                        Robj3[i2].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);//希望する値
                        Robj3[i2].GetComponent<Text>().text = str3[i2];
                        Robj3[i2].GetComponent<Text>().color = new Color(1, 0, 0, 1);
                    }
                }
            }
            if (i == 3)
            {
                if (sw == false)
                {
                    arr4 = GetText.debris[problem_num, i, 0];
                    obj4 = new GameObject[arr4.Length];
                }
                else
                {
                    arr4 = GetText.debris[problem_num, i, 2];
                    Robj4 = new GameObject[arr4.Length];
                }

                str4 = new string[arr4.Length];

                for (int i2 = 0; i2 < arr4.Length; i2++)
                {
                    str4[i2] = arr4[i2].ToString();
                    if (arr4.Length % 2 == 0)//文字数が遇数なら
                    {
                        text_x = transform.position.x + ((i2 - (arr4.Length / 2) + 0.5f) / width);
                    }
                    else//文字数が奇数なら
                    {
                        if (i2 == (arr4.Length - 1) / 2)
                        {
                            text_x = transform.position.x;
                        }
                        else
                        {
                            text_x = transform.position.x + ((-((arr4.Length - 1) / 2) + i2) / width);
                        }
                    }
                    if (sw == false)
                    {
                        obj4[i2] = Instantiate(prefab, new Vector2(text_x + level_text_x, transform.position.y - y), transform.rotation);
                        obj4[i2].transform.parent = transform;
                        obj4[i2].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);//希望する値
                        obj4[i2].GetComponent<Text>().text = str4[i2];
                    }
                    else
                    {
                        Robj4[i2] = Instantiate(prefab, new Vector2(text_x + level_text_x, transform.position.y - y), transform.rotation);
                        Robj4[i2].transform.parent = transform;
                        Robj4[i2].transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);//希望する値
                        Robj4[i2].GetComponent<Text>().text = str4[i2];
                        Robj4[i2].GetComponent<Text>().color = new Color(1, 0, 0, 1);
                    }
                }
            }
        }
    }

    void text_Destroy()
    {
        if (level > 0)
        {
            for (int i = 0; i < obj.Length; i++)
            {
                Destroy(obj[i]);
            }
            for (int i = 0; i < obj2.Length; i++)
            {
                Destroy(obj2[i]);
            }

            for (int i = 0; i < Robj.Length; i++)
            {
                Destroy(Robj[i]);
            }
            for (int i = 0; i < Robj2.Length; i++)
            {
                Destroy(Robj2[i]);
            }
        }
        if (level > 1)
        {
            for (int i = 0; i < obj3.Length; i++)
            {
                Destroy(obj3[i]);
            }

            for (int i = 0; i < Robj3.Length; i++)
            {
                Destroy(Robj3[i]);
            }
        }
        if (level > 2)
        {
            for (int i = 0; i < obj4.Length; i++)
            {
                Destroy(obj4[i]);
            }

            for (int i = 0; i < Robj4.Length; i++)
            {
                Destroy(Robj4[i]);
            }
        }
    }

    void text_update()
    {
        if (count < Robj.Length-1)
        {
            Robj[count].GetComponent<Text>().color = new Color(0, 0, 0, 0.25f);
            count++;
        }
        else
        {
            if (Answer == 0)
            {
                Robj[count].GetComponent<Text>().color = new Color(0, 0, 0, 0.25f);
                count = 0;
                count2 = 0;
                count3 = 0;
                count4 = 0;
                StartCoroutine("SamplecoRoutine"); //動く
            }
            else
            {
                Robj[count].GetComponent<Text>().color = new Color(0, 0, 0, 0.25f);
                Debug.Log("不正解");
            }
        }
    }

    void text_update2()
    {
        if (count2 < Robj2.Length-1)
        {
            Robj2[count2].GetComponent<Text>().color = new Color(0, 0, 0, 0.25f);
            count2++;
        }
        else
        {
            if (Answer == 1)
            {
                Robj2[count2].GetComponent<Text>().color = new Color(0, 0, 0, 0.25f);
                count = 0;
                count2 = 0;
                count3 = 0;
                count4 = 0;
                StartCoroutine("SamplecoRoutine"); //動く
            }
            else
            {
                Robj2[count2].GetComponent<Text>().color = new Color(0, 0, 0, 0.25f);
                Debug.Log("不正解");
            }
        }
    }

    void text_update3()
    {
        if (count3 < Robj3.Length-1)
        {
            Robj3[count3].GetComponent<Text>().color = new Color(0, 0, 0, 0.25f);
            count3++;
        }
        else
        {
            if (Answer == 2)
            {
                Robj3[count3].GetComponent<Text>().color = new Color(0, 0, 0, 0.25f);
                count = 0;
                count2 = 0;
                count3 = 0;
                count4 = 0;
                StartCoroutine("SamplecoRoutine"); //動く
            }
            else
            {
                Robj3[count3].GetComponent<Text>().color = new Color(0, 0, 0, 0.25f);
                Debug.Log("不正解");
            }
        }
    }

    void text_update4()
    {
        if (count4 < Robj4.Length-1)
        {
            Robj4[count4].GetComponent<Text>().color = new Color(0, 0, 0, 0.25f);
            count4++;
        }
        else
        {
            if (Answer == 3)
            {
                Robj4[count4].GetComponent<Text>().color = new Color(0, 0, 0, 0.25f);
                count = 0;
                count2 = 0;
                count3 = 0;
                count4 = 0;
                StartCoroutine("SamplecoRoutine"); //動く
            }
            else
            {
                Robj4[count4].GetComponent<Text>().color = new Color(0, 0, 0, 0.25f);
                Debug.Log("不正解");
            }
        }
    }

    IEnumerator SamplecoRoutine()//コルーチン。遅延用の処理
    {
        Debug.Log("コルーチン内で起動");
        yield return new WaitForSeconds(2.0f);
        text_Destroy();
        problem_num++;
        if (clear_num <= problem_num)
        {
            Debug.Log("クリア判定");
            //OnRisult.flag = true;
            SceneManager.LoadScene("Result");
        }
        answer_check();
        main_text.text_change();
        text_Generate(text.text, 0, false, 5, problem_num);
        text_Generate(roma.text, 0.5f, true, 5, problem_num);
        CheckTestScript.LoadText();
    }
}
