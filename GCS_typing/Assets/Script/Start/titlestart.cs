
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class titlestart : MonoBehaviour
{
    [SerializeField] AudioClip enter;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnClickStartButton() //https://dianxnao.com/ボタンクリックでシーン間を遷移%ef%bc%88移動%ef%bc%89する/
    {
        Debug.Log("原稿選択へ");
        audioSource.PlayOneShot(enter);
        //SceneManager.LoadScene("Choice");
        feadSC.fade("Choice");
    }

    public void Credit() //https://dianxnao.com/ボタンクリックでシーン間を遷移%ef%bc%88移動%ef%bc%89する/
    {
        audioSource.PlayOneShot(enter);
        // SceneManager.LoadScene("Favorite");
        feadSC.fade("Favorite");
    }
}
