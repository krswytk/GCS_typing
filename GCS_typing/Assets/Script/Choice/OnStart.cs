using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class OnStart : MonoBehaviour
{
    [SerializeField] AudioClip sound1;
    AudioSource audioSource;
    FileNumber FN;
    int num;//原稿数を格納
    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
        FN = GameObject.Find("TestManuscripS").GetComponent<FileNumber>();
        num = FN.GetFN();
    }

    public void OnStarts()
    {
        SceneManager.sceneLoaded += GameSceneLoaded;

        audioSource.PlayOneShot(sound1);
        SceneManager.LoadScene("Main");
    }

    private void GameSceneLoaded(Scene next, LoadSceneMode mode)
    {
        GetText GT = GameObject.Find("GetText").GetComponent<GetText>();


        GT.text = new string[num];
        GT.word = new string[num];
        GT.meaning = new string[num];

        for (int i = 0; i < num; i++) {
            GT.text[i] = FN.M[i].GetText();
            GT.word[i] = FN.D[i].GetWord();
            GT.meaning[i] = FN.D[i].GetMeaning();
        }
        
        SceneManager.sceneLoaded -= GameSceneLoaded;
        
    }
}
