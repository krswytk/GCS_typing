using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class NodePrefub : MonoBehaviour
{

    [SerializeField]
    RectTransform prefab = null;
    [SerializeField]
    private TextAsset textAsset;
    private string loadText1;
    private string[] splitText1;
    private string[] splitText2;
    Dictionary dictionary;
    public InputField inputField;
    public GetText g_text;
    void Start()
    {
        loadText1 = textAsset.text;
        splitText1 = loadText1.Split(char.Parse("\n"));
        splitText2 = loadText1.Split(new char[] {' ', '\n'});
        inputField = inputField.GetComponent<InputField>();
        g_text = g_text.GetComponent<GetText>();
        for (int i = 0; i < splitText1.Length - 2; i++)
        {
            for (int j = 0; j < g_text.word.Length; j++)
            {

                if (g_text.word[j] == splitText2[i * 3])
                {
                    var item = GameObject.Instantiate(prefab) as RectTransform;
                    item.name = "node" + i;
                    item.SetParent(transform, false);

                    var text = item.GetComponentInChildren<Text>();
                    var g_object = item.GetComponent<GetClickedText>();

                    text.text = splitText2[i * 3];
                    g_object.setNumber(i);

                }
            }

        }
    }
    public void InputText()
    {
        //テキストにinputFieldの内容を反映
        for (int i = 0; i < splitText1.Length - 2; i++)
        {
            if (inputField.text == "")
            {
                for (int j = 0; j < g_text.word.Length; j++)
                {
                    if (g_text.word[j] == splitText2[i * 3])
                    {
                        GameObject obj = GameObject.Find("node" + i);
                        Destroy(obj);

                        var item = GameObject.Instantiate(prefab) as RectTransform;
                        item.name = "node" + i;
                        item.SetParent(transform, false);

                        var text = item.GetComponentInChildren<Text>();
                        var g_object = item.GetComponent<GetClickedText>();

                        text.text = splitText2[i * 3];
                        g_object.setNumber(i);
                    }
                }
            }
            else if (splitText2[i * 3].Contains(inputField.text) || splitText2[i * 3 + 1].Contains(inputField.text))
            {

                if (GameObject.Find("node" + i) == false)
                {
                    for (int j = 0; j < g_text.word.Length; j++)
                    {
                        if (g_text.word[j] == splitText2[i * 3])
                        {

                            var item = GameObject.Instantiate(prefab) as RectTransform;
                            item.name = "node" + i;
                            item.SetParent(transform, false);

                            var text = item.GetComponentInChildren<Text>();
                            var g_object = item.GetComponent<GetClickedText>();

                            text.text = splitText2[i * 3];
                            g_object.setNumber(i);
                        }
                    }
                }
                
                
            }
            else
            {

                //Debug.Log("呼び出された" + i);
                GameObject obj = GameObject.Find("node" + i);
                Destroy(obj);
                

            }
        }
        

    }
}