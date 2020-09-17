using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//キー入力判定スクリプト

public class CheckKey : MonoBehaviour
{
    private SelectDisplay SelectDisplay;

    private AllManeger AllManeger;

    private GetText GetText;

    private string[,] Roma;


    // Start is called before the first frame update
    void Start()
    {
        SelectDisplay = this.GetComponent<SelectDisplay>();
        GetText = GameObject.Find("GetText").GetComponent<GetText>();//ゲットテキストのゲットテキストスクリプトを取得

        for (int i = 0; i < AllManeger.GetProblemNumber(); i++)
        {
            for (int l = 0; l < AllManeger.GetDifficulty(); l++)
            {
                Roma[i, l] = GetText.debris[i, l, 2];
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)//何かキーが押された
        {
            check();
        }
    }
    void check()
    {

    }
}
