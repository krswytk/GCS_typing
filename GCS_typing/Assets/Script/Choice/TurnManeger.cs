﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TurnManeger : MonoBehaviour
{
    private GenerateDictionary GD;
    private FileNumber FN;
    private Onturn OT;

    [SerializeField] GameObject[] str;
    int num;

    [SerializeField] GameObject title;
    Text text;

    bool sw = false;
    // Start is called before the first frame update
    void Start()
    {
        GD = this.GetComponent<GenerateDictionary>();
        FN = this.GetComponent<FileNumber>();
        OT = this.GetComponent<Onturn>();
        text = title.GetComponent<Text>();


    }

    // Update is called once per frame
    void Update()
    {
        if (sw == false)
        {
            num = OT.GetNum();
            Debug.Log(OT.GetNum());
            Change();
            sw = true;
        }
        if (num != OT.GetNum())
        {
            Debug.Log(OT.GetNum());
            num = OT.GetNum();
            Change();
        }
    }

    private void Change()
    {
        Debug.Log("ChangeON");
        text.text = FN.D[num].GetTitle();
        OnStr();
    }
    private void OnStr()
    {
        for(int i = 0; i < str.Length; i++)
        {
            str[i].SetActive(false);
        }
        
        switch (FN.D[num].GetNumber())
        {
            case 1: str[0].SetActive(true); break;
            case 2: str[1].SetActive(true); break;
            case 3: str[2].SetActive(true); break;
            case 4: str[3].SetActive(true); break;
            case 5: str[4].SetActive(true); break;
            default:break;
        }
    }
}
