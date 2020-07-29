using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Onturn : MonoBehaviour
{
    [SerializeField] private GameObject Manuscript;//回転画像の親オブジェクトを格納

    private int Number;//生成する原稿数

    private maneger s;

    Transform Manuscripttrn;
    Vector3 Angle;

    private void Start()
    {

        if(Manuscript == null){
            Manuscript = GameObject.Find("TestManuscripS");
        }

         s = Manuscript.GetComponent<maneger>();

        Number = s.GetN();

        Manuscripttrn = Manuscript.GetComponent<Transform>();
        Angle = Manuscripttrn.eulerAngles;
    }

    public void OnRight()
    {
        for (int i = 0; i < 10; i++)
        {
            StartCoroutine(DelayMethod(i * 0.05f, () =>
            {
                Debug.Log("実行"+i);
                Angle.y -= 360 / Number/10;
                Manuscripttrn.eulerAngles = Angle;
            }));
        }
        //Debug.Log("回転");
    }

    public void OnLeft()
    {
        Angle.y += 360 / Number;
        Manuscripttrn.eulerAngles = Angle;
    }

    private IEnumerator DelayMethod(float waitTime, Action action)
    {
        yield return new WaitForSeconds(waitTime);
        action();
    }
}
