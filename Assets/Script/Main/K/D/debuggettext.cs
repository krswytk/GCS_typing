using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debuggettext : MonoBehaviour
{
    GetText GetText;
    // Start is called before the first frame update
    void Start()
    {
        GetText = GameObject.Find("GetText").GetComponent<GetText>();
        for (int i = 0; i < GetText.word.Length; i++)
        {
            Debug.Log(GetText.word[i]);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
