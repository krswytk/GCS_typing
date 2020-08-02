using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnManuscript : MonoBehaviour
{
    private bool Display;//原稿本文を表示中かどうかの判定


    // Start is called before the first frame update
    void Start()
    {
        Display = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnManuscripts()
    {
        Display = true;

    }
}
