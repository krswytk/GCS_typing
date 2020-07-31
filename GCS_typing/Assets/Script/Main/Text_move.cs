using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text_move : MonoBehaviour
{
    public Text_Lenth Text_Lenth;
    int ret = 0;
    int[] Lenth;
    int Line = 0;
    bool sw=false;

    Transform myTransform;
    Vector3 pos;
    Vector3 add;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = this.transform;
        pos = myTransform.position;
        add = myTransform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (sw==false)
        {
            ret = Text_Lenth.ret;
            Lenth= new int[ret + 1];
            for (int i = 0; i < ret + 1; i++)
            {
                Lenth[i] = Text_Lenth.LineLenth[i];
                //Debug.Log(Lenth[i]);
            }
            add.x = -5.4f - (((Lenth[Line] - 1) / 2) * 0.24f);
            if (ret % 2 == 0)//奇数 次ここ
            {
                //add.y = 1.6f + ((ret/2)* 0.13f);
                add.y = 1.9f;
                Debug.Log("ret % 2 == 0");
            }
            else//偶数　ここは完成
            {
                add.y = 1.6f + (((ret - 1) / 2) * 0.27f);
                Debug.Log("ret % 2 == 1");
            }
            myTransform.position = add;
            sw = true;
        }


        if (Input.GetKey(KeyCode.Space))// 9文字で2.1だけ移動
        {
            if ((add.x - pos.x) < (Lenth[Line] - 7) * 0.23)
            {
                add.x += 0.02f;
                myTransform.position = add;
            }else
            {
                Line++;
                add.y -= 0.27f;//行を下に移動1.95 1.579
                add.x = -5.4f - (((Lenth[Line] - 1) / 2) * 0.24f);//9文字で2
                pos.x = -5.4f - (((Lenth[Line] - 1) / 2) * 0.24f);
                myTransform.position = add;
            }
        }
        Debug.Log(myTransform.position);
    }
}