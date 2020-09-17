using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seavdate : MonoBehaviour {

    private string[] saveword;
    FileNumber FN;

    // Start is called before the first frame update
    void Start()
    {
        FN = GameObject.Find("TestManuscripS").GetComponent<FileNumber>();

        saveword = new string[FN.count];//単語数分確保

        for (int i = 0; i < FN.count; i++)
        {
            saveword[i] = FN.D[i].GetWord();//sevewordに全単語を代入
        }

        bunkaitextAnser();
    }

    // Update is called once per frame
    void Update()
    {
      //  PlayerPrefs.SetString("Data", "SaveData");

    }

    void bunkaitextAnser()
    {
      //  string[] w = FN.NM[TM.GetTMnum()].GetText()
    }
}
