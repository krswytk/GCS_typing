using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class OnStart : MonoBehaviour
{
    [SerializeField] AudioClip sound1;
    AudioSource audioSource;
    FileNumber FN;
    TurnManeger TM;
    int num;//原稿数を格納
    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
        FN = GameObject.Find("TestManuscripS").GetComponent<FileNumber>();
        TM = GameObject.Find("TestManuscripS").GetComponent<TurnManeger>();
        num = FN.GetFN();
    }

    public void OnStarts()
    {
        SceneManager.sceneLoaded += GameSceneLoaded;

        audioSource.PlayOneShot(sound1);
        SceneManager.LoadScene("NewMain");
    }

    private void GameSceneLoaded(Scene next, LoadSceneMode mode)
    {
        GetText GT = GameObject.Find("GetText").GetComponent<GetText>();

        /////////辞書部分の渡し
        GT.word = new string[FN.count];
        Debug.Log(FN.count);
        GT.meaning = new string[FN.count];
        
        for (int i = 0; i < FN.count; i++)
        {
            GT.word[i] = FN.D[i].GetWord();
            GT.meaning[i] = FN.D[i].GetMeanings();
        }
        /////////////

        
        ///////////原稿の渡し
        GT.text = FN.NM[TM.GetTMnum()].GetText();
        GT.debris = FN.NM[TM.GetTMnum()].GetDebris();
        /////////////

        SceneManager.sceneLoaded -= GameSceneLoaded;
        
    }
}
