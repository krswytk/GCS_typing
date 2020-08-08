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

    // Start is called before the first frame update
    void Start()
    {
        loadText1 = textAsset.text;
        splitText1 = loadText1.Split(char.Parse("\n"));
        splitText2 = loadText1.Split(char.Parse(" "));
    }

    // Update is called once per frame
    void Update()
    {
        Text text = _text.GetComponent<Text>();
        text.text = splitText1[meanNumber];
    }
    public void numberSet(int number)
    {
        meanNumber = number;
    }
}
