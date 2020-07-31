using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text_move : MonoBehaviour
{
    public Text_Lenth Text_Lenth;
    int ret=0;
    int[] Lenth;
    int Line = 0;
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

        if (ret == 0)
        {
            ret = Text_Lenth.ret;
            Lenth= new int[ret + 1];
            for (int i = 0; i < ret + 1; i++)
            {
                Lenth[i] = Text_Lenth.LineLenth[i];
                //Debug.Log(Lenth[i]);
            }
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
                add.x = -7.61f;
                pos.x = -7.61f;
                myTransform.position = add;
            }
        }
        Debug.Log(myTransform.position);
    }
}