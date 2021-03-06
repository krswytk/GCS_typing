﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnManuscript : MonoBehaviour
{
    [SerializeField] private GameObject Manuscript;//原稿オブジェクトを格納
    [SerializeField] private GameObject CDO;//原稿オブジェクトを格納

    private bool sw;
    ContentDisplay CD;
    // Start is called before the first frame update
    void Start()
    {
        sw = false;
        cs();
        CD = CDO.GetComponent<ContentDisplay>();
    }

    // Update is called once per frame
    void Update()
    {
        if(sw == true)
        {
            if (Input.GetMouseButton(0))
            {
                sw = false;
                cs();
            }
        }
    }

    public void ButtonManuscript()
    {
        sw = true;
        cs();
    }

    private void cs()
    {
        if(sw == true)//表示処理
        {
            Manuscript.SetActive(true);
            CD.CT();
        }
        else//非表示処理
        {
            Manuscript.SetActive(false);
        }

    }
}
