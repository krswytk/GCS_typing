using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text_Lenth : MonoBehaviour
{
    [SerializeField] private Text text;
    public static int[] LineLenth;
    public static int ret;
    bool sw=false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (sw == false)//行ごとの文字数をLineLenth[i]に格納
        {
            GetLengh(text.text);
            for (int i = 0; i < ret + 1; i++)
            {
               // Debug.Log(LineLenth[i]);
            }
            sw = true;
        }

    }

    void GetLengh(string str)
    {
        string a = str;

        string before = str;
        string after = str.Replace("\n", "");
        ret = before.Length - after.Length;


        int[] Lenth = new int[ret+1];
        LineLenth = new int[ret + 1];

        //Debug.Log(ret);

        for (int i=0;i<ret;i++)
        {
            if (i != 0)
            {
                Lenth[i] = a.IndexOf('\n', Lenth[i-1]+i+i+2)-i-i-1;
            }
            else
            {
                Lenth[i] = a.IndexOf('\n', 0) - 1;
            }

            //Debug.Log("Lenth:" + Lenth[i]+"  i:" + i);
        }
        Lenth[ret] = before.Length - (ret) - (ret);
        //Debug.Log("Lenth:" + Lenth[ret] + "  i:" + ret);

        for (int i = 0; i < ret+1; i++)
        {
            if (i != 0)
            {
                LineLenth[i] = Lenth[i]- Lenth[i-1];
            }
            else
            {
                LineLenth[i] = Lenth[i];
            }
        }
    }
}
