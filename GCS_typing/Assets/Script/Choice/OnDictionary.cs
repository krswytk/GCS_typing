using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnDictionary : MonoBehaviour
{
    [SerializeField] AudioClip sound1;
    AudioSource audioSource;
    FileNumber FN;
    int num;//単語数
    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
        FN = GameObject.Find("TestManuscripS").GetComponent<FileNumber>();
        num = FN.count;
    }

    public void OnDictionarys()
    {
        SceneManager.sceneLoaded += GameSceneLoaded;

        audioSource.PlayOneShot(sound1);
        SceneManager.LoadScene("Dictionary");
    }
    
    private void GameSceneLoaded(Scene next, LoadSceneMode mode)
    {
        GeterText GT = GameObject.Find("GeterText").GetComponent<GeterText>();

        GT.word = new string[num];
        GT.hiragana = new string[num];
        GT.meaning = new string[num];

        for (int i = 0; i < num; i++)
        {
            GT.word[i] = FN.D[i].GetWord();
            GT.hiragana[i] = FN.D[i].GetHiragana();
            GT.meaning[i] = FN.D[i].GetMeaning();
            //Debug.Log(FN.M[i].GetText());
        }

        SceneManager.sceneLoaded -= GameSceneLoaded;
    }

}