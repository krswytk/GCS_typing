using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllManeger : MonoBehaviour
{
    private int Number;//現在の問題番号0~9
    private int Difficulty;//難易度を格納
    private GetText GetText;
    [SerializeField] private GameObject Basket;

    // Start is called before the first frame update
    void Awake()//各種初期値の設定を行う
    {
        GetText = GameObject.Find("GetText").GetComponent<GetText>();//ゲットテキストのゲットテキストスクリプトを取得
        Number = 0;
        Difficulty = GetText.debris.GetLength(1);//難易度を格納
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
        return Difficulty;
    }
    public GameObject GetBasket()
    {
        return Basket;
    }
}
