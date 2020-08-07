using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class meaning : MonoBehaviour
{
    [SerializeField] private Text dataText;
    [SerializeField] private TextAsset textAsset;
    private string loadText1;

    void Start()
    {
        loadText1 = textAsset.text;
        loadText1 = loadText1.Replace("1", "１");
        loadText1 = loadText1.Replace("2", "２");
        loadText1 = loadText1.Replace("3", "３");
        loadText1 = loadText1.Replace("4", "４");
        loadText1 = loadText1.Replace("5", "５");
        loadText1 = loadText1.Replace("6", "６");
        loadText1 = loadText1.Replace("7", "７");
        loadText1 = loadText1.Replace("8", "８");
        loadText1 = loadText1.Replace("9", "９");
        loadText1 = loadText1.Replace("0", "０");
        //if(loadText1.Length>42)
        dataText.text = loadText1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
