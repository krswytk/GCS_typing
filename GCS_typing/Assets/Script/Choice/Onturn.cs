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

    //float sin = Mathf.Sin(Time.time);
    //float cos = Mathf.Cos(Time.time);

    [SerializeField] float stage = 10;//1押し何段階で次の原稿に回るか
    [SerializeField] float time = 0.05f;//1段階の進むのにかかる時間　time * stage が1押し分の所要時間
    float y;

    private void Start()
    {
        if(Manuscript == null){
            Manuscript = GameObject.Find("TestManuscripS");
        }

         s = Manuscript.GetComponent<maneger>();

        Number = s.GetN();

        Manuscripttrn = Manuscript.GetComponent<Transform>();
        Angle = Manuscripttrn.eulerAngles;

        y = 360 / Number / stage;
    }

    public void OnRight()
    {
        for (int i = 0; i < stage; i++)
        {
            StartCoroutine(DelayMethod(i * time, () =>
            {
                Angle.y -= y;
                Angle.x = Mathf.Cos(Angle.y * Mathf.Deg2Rad) * -10;
                Angle.z = Mathf.Sin(Angle.y * Mathf.Deg2Rad) * -10;
                Manuscripttrn.eulerAngles = Angle;
            }));
        }
    }

    public void OnLeft()
    {
        Angle.y += y;
        Manuscripttrn.eulerAngles = Angle;
    }

    private IEnumerator DelayMethod(float waitTime, Action action)
    {
        yield return new WaitForSeconds(waitTime);
        action();
    }
}
