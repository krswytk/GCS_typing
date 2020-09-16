using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllManeger : MonoBehaviour
{
    private int Number;//現在の問題番号0~9
    private int Difficulty;//難易度を格納
    private GetText GetText;
    [SerializeField] private GameObject Basket;
    [SerializeField] private GameObject BasketBox;

    // Start is called before the first frame update
    void Awake()//各種初期値の設定を行う
    {
        GetText = GameObject.Find("GetText").GetComponent<GetText>();//ゲットテキストのゲットテキストスクリプトを取得
        Number = 0;
    }

    void Start()//各種初期値の設定を行う
    {
        try
        {
            Difficulty = GetText.debris.GetLength(1);//難易度を格納
        }
        catch (NullReferenceException)
        {
            Difficulty = 3;//デバッグ用
        }
    }
        // Update is called once per frame
        void Update()
    {
        
    }

    public int GetNumber()
    {
        return Number;
    }
    public int GetDifficulty()
    {
        Debug.Log("難易度送り込み" + Difficulty);
        return Difficulty;
    }
    public GameObject GetBasket()
    {
        return Basket;
    }
    public GameObject GetBasketBox()
    {
        return BasketBox;
    }
}
