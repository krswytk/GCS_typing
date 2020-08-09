using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetText : MonoBehaviour
{
    public string text;
    public string[] word;
    public string[] meaning;

    private void Start()
    {
        Debug.Log(text);
        Debug.Log(word[0]);
        Debug.Log(meaning[0]);
        Debug.Log(word[1]);
        Debug.Log(meaning[1]);
        Debug.Log(word[2]);
        Debug.Log(meaning[2]);
    }
}
