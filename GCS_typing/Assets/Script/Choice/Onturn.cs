using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Onturn : MonoBehaviour
{
    [SerializeField] private GameObject Manuscript;//回転画像の親オブジェクトを格納

    private int Number;//生成する原稿数

    public static int Num;//現在最前に来ている原稿の番号0からNumber-1
    
    private FileNumber FN;

    Transform Manuscripttrn;
    Vector3 Angle;

    //float sin = Mathf.Sin(Time.time);
    //float cos = Mathf.Cos(Time.time);

    [SerializeField] float stage = 10;//1押し何段階で次の原稿に回るか
    [SerializeField] float time = 0.05f;//1段階の進むのにかかる時間　time * stage が1押し分の所要時間
    float y;

    private bool sw = false;

    [SerializeField] AudioClip sound1;
    AudioSource audioSource;
    private void Start()
    {
        if(Manuscript == null){
            Manuscript = GameObject.Find("TestManuscripS");
        }
        
        FN = Manuscript.GetComponent<FileNumber>();


        Manuscripttrn = Manuscript.GetComponent<Transform>();
        Angle = Manuscripttrn.eulerAngles;

        Num = 0;

        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (sw == false)
        {
            Number = FN.GetFN();
            //Debug.Log(Number);
            y = 360 / Number / stage;
            sw = true;
        }
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

        Num++;
        if(Num == Number)
        {
            Num = 0;
        }
        audioSource.PlayOneShot(sound1);
    }

    public void OnLeft()
    {
        for (int i = 0; i < stage; i++)
        {
            StartCoroutine(DelayMethod(i * time, () =>
            {
                Angle.y += y;
                Angle.x = Mathf.Cos(Angle.y * Mathf.Deg2Rad) * -10;
                Angle.z = Mathf.Sin(Angle.y * Mathf.Deg2Rad) * -10;
                Manuscripttrn.eulerAngles = Angle;
            }));
        }

        Num--;
        if (Num == -1)
        {
            Num = Number - 1;
        }
        audioSource.PlayOneShot(sound1);
    }

    private IEnumerator DelayMethod(float waitTime, Action action)
    {
        yield return new WaitForSeconds(waitTime);
        action();
    }

    public int GetNum()
    {
        return Num;
    }
}
