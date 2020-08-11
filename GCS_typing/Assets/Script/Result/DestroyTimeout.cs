﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyTimeout : MonoBehaviour
{
    [SerializeField] private GameObject Difficulty;
    [SerializeField] private GameObject an;
    [SerializeField] private GameObject tx;
    [SerializeField] private GameObject tx2;
    public float outtimer = 15.0f;
    int seconds;

    [SerializeField] private Sprite[] anImage; 
    private string[] text;
    private Text t,t2;
    private Image i;

    private int n;

    [SerializeField] AudioClip[] sound;
    private AudioSource audioSource;
    // [SerializeField] private sp

    // Start is called before the first frame update
    void Start()
    {
        //Difficulty = GameObject.Find("Difficulty");
        Destroy(Difficulty, outtimer);

        text = new string[5];
        text[0] = "流石です！\nこれなら安心して\n任せられますね！";
        text[1] = "概ね良好ですね。\n完璧な原稿まで\nもう少しですよ！";
        text[2] = "可もなく不可もなくと\nいった感じですね。\nまだまだ成長できますよ！";
        text[3] = "ミスが少々目立ちますね。\nもっと頑張りましょう！";
        text[4] = "・・・練習あるのみですね。";

        t = tx.GetComponent<Text>();
        t2 = tx2.GetComponent<Text>();
        i = an.GetComponent<Image>();

        n = 5;
        c();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0)){
            c();
        }
        outtimer -= Time.deltaTime;
        seconds = (int)outtimer+1;
        t2.text = seconds.ToString() + "秒後にセレクト画面に移行します";
    }

    private void c()
    {
        n++;
        if(n > 4)
        {
            n = 0;
        }
        t.text = text[n];
        i.sprite = anImage[n];
        audioSource.PlayOneShot(sound[n]);

    }
}
