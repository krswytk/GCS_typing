using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectManeger : MonoBehaviour
{
    private GetText GetText;
    private AllManeger AllManeger;
    private int number;
    private int Difficulty;//デブリの数＝難易度を格納する
    private GameObject Basket;
    private GameObject[] Box;



    // Start is called before the first frame update
    void Start()
    {
        GetText = GameObject.Find("GetText").GetComponent<GetText>();//ゲットテキストのゲットテキストスクリプトを取得
        AllManeger = this.GetComponent<AllManeger>();
        number = AllManeger.GetNumber();//ゲットテキストのゲットテキストスクリプトを取得
        Difficulty = AllManeger.GetDifficulty();//難易度を格納
        Basket = AllManeger.GetBasket();
        Box = new GameObject[Difficulty];
        GenerateBox();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void GenerateBox()
    {
        int n = 0;
        switch (Difficulty)
        {
            case 2:
                Box[n] = Instantiate(Basket,new Vector2(610f, 670f), Quaternion.identity);
                n++;
                Box[n] = Instantiate(Basket, new Vector2(1310f, 670f), Quaternion.identity);
                n++;
                break;
            case 3:
                Box[n] = Instantiate(Basket, new Vector2(510f, 670f), Quaternion.identity);
                n++;
                Box[n] = Instantiate(Basket, new Vector2(960f, 670f), Quaternion.identity);
                n++;
                Box[n] = Instantiate(Basket, new Vector2(1410f, 670f), Quaternion.identity);
                n++;
                break;
            case 4:
                Box[n] = Instantiate(Basket, new Vector2(310f, 670f), Quaternion.identity);
                n++;
                Box[n] = Instantiate(Basket, new Vector2(730f, 670f), Quaternion.identity);
                n++;
                Box[n] = Instantiate(Basket, new Vector2(1190f, 670f), Quaternion.identity);
                n++;
                Box[n] = Instantiate(Basket, new Vector2(1610f, 670f), Quaternion.identity);
                n++;
                break;
            default:Debug.LogError("選択肢表示のボックス生成でエラー");break;
        }
    }
}
