using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class OnRisult : MonoBehaviour
{
    [SerializeField] AudioClip sound1;
    AudioSource audioSource;

    public bool flag;

    public void Start()
    {
        flag = false;
    }
    private void Update()
    {
        if (flag)
        {
            Debug.Log("OnStarts");
            OnStarts();
        }
    }

    public void OnStarts()
    {
        SceneManager.sceneLoaded += GameSceneLoaded;

        //audioSource.PlayOneShot(sound1);素材アタッチしたら//消して
        SceneManager.LoadScene("Result");
    }

    private void GameSceneLoaded(Scene next, LoadSceneMode mode)
    {
        DestroyTimeout DT = GameObject.Find("EventSystem").GetComponent<DestroyTimeout>();

        DT.SetScore(4);//リザルトにスコアを渡す0-4

        SceneManager.sceneLoaded -= GameSceneLoaded;

    }
}
