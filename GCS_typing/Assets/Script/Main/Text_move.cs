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

            if (Lenth[Line] % 2 == 0)
            {
                add.x = -5.2f - (((Lenth[Line]) / 2) * 0.23f);
                pos.x = -5.2f - (((Lenth[Line]) / 2) * 0.23f);
                //Debug.Log("Lenth[Line] % 2 == 0");
            }
            else
            {
                add.x = -5.3f - (((Lenth[Line] - 1) / 2) * 0.23f);
                pos.x = -5.3f - (((Lenth[Line] - 1) / 2) * 0.23f);
                //Debug.Log("Lenth[Line] % 2 == 1");
            }

            if (ret % 2 == 0)//奇数 次ここ ret=0は一行目　2は3行目
            {
                //add.y = 1.6f + ((ret/2)* 0.13f);
                //add.y = 1.6f + (((ret / 2) * 0.072f)* (ret / 2));
                add.y = 1.45f + ((ret/ 2) * 0.27f);
                //Debug.Log("ret % 2 == 0");
            }
            else//偶数　ここは完成
            {
                add.y = 1.6f + (((ret - 1) / 2) * 0.27f);
                //Debug.Log("ret % 2 == 1");
            }
            myTransform.position = add;
            sw = true;
        }


        if (Input.GetKeyDown(KeyCode.Space))// 9文字で2.1だけ移動
        {
            if (Line < ret + 1)
            {
                if ((add.x - pos.x) < (Lenth[Line] - 2) * 0.234)
                {
                    add.x += 0.233f;
                    myTransform.position = add;
                }
                else//奇数と偶数分け
                {
                    Line++;
                    add.y -= 0.27f;//行を下に移動1.95 1.579

                    if (Lenth[Line] % 2 == 0)
                    {
                        add.x = -5.2f - (((Lenth[Line]) / 2) * 0.23f);
                        pos.x = -5.2f - (((Lenth[Line]) / 2) * 0.23f);
                        //Debug.Log("Lenth[Line] % 2 == 0");
                    }
                    else
                    {
                        add.x = -5.3f - (((Lenth[Line] - 1) / 2) * 0.23f);
                        pos.x = -5.3f - (((Lenth[Line] - 1) / 2) * 0.23f);
                        //Debug.Log("Lenth[Line] % 2 == 1");
                        //Debug.Log((((Lenth[Line] - 1) / 2) * 0.241f));
                    }

                    //add.x = -5.25f - (((Lenth[Line] - 1) / 2) * 0.24f);//9文字で2
                    //pos.x = -5.25f - (((Lenth[Line] - 1) / 2) * 0.24f);
                    myTransform.position = add;
                }
                //Debug.Log("Line:" + Line + "ret:" + ret);//17文字 7.22 7.1425  7文字  6.02
            }else
            {
                Debug.Log("CLEAR!");
            }
        }
        
    }
}