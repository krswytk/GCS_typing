using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Text_move : MonoBehaviour
{
    [SerializeField] private Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int lineCnt = GetLengh(text.text);
        }
    }

    int GetLengh(string str)
    {
        string a = str;

        string before = str;
        string after = str.Replace("\n", "");
        int ret = before.Length - after.Length;


        int[] Lenth = new int[ret+1];

        Debug.Log(ret);

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

            Debug.Log("Lenth:" + Lenth[i]+"  i:" + i);
        }
        Lenth[ret] = before.Length - (ret) - (ret);
        Debug.Log("Lenth:" + Lenth[ret] + "  i:" + ret);

        return ret;
    }
}
