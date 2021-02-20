using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class mean : MonoBehaviour
{
    public static int meanNumber;

    [SerializeField]
    private Text _text;
    [SerializeField]
    private TextAsset textAsset;
    private string loadText1;
    private string loadText2;
    private string[] splitText1;
    private string[] splitText2;
    public GetText g_text;

    // Start is called before the first frame update
    void Start()
    {
        loadText1 = textAsset.text;
        splitText1 = loadText1.Split(char.Parse("\n"), char.Parse(" "));
        splitText2 = loadText1.Split(char.Parse(" "));

        for(int i = 0;i < splitText1.Length;i++)
            splitText1[i] = splitText1[i].Replace("/", "");
        g_text = g_text.GetComponent<GetText>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(g_text.word[3]);
        if (g_text.word.Length > 0)
        {
            Text text = _text.GetComponent<Text>();
            text.text = splitText1[meanNumber * 3] + "\n" + splitText1[meanNumber * 3 + 1] + "\n" + splitText1[meanNumber * 3 + 2];
        }
       
    }
    public void numberSet(int number)
    {
        meanNumber = number;
    }
}
