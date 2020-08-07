using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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
    void Start()
    {
        loadText1 = textAsset.text;
        splitText1 = loadText1.Split(char.Parse("\n"));
        splitText2 = loadText1.Split(new char[] {' ', '\n'});

        for (int i = 0; i < splitText1.Length - 2; i++)
        {
            if (dictionary.GetText() == splitText2[i * 3])
            {
                var item = GameObject.Instantiate(prefab) as RectTransform;
                item.SetParent(transform, false);

                var text = item.GetComponentInChildren<Text>();
                var g_object = item.GetComponent<GetClickedText>();
                
                text.text = splitText2[i * 3];
                g_object.setNumber(i);
            }
        }
    }
}