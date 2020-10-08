
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class titlestart : MonoBehaviour
{

    public void OnClickStartButton() //https://dianxnao.com/ボタンクリックでシーン間を遷移%ef%bc%88移動%ef%bc%89する/
    {
        Debug.Log("原稿選択へ");
        SceneManager.LoadScene("Choice");
    }

    public void Credit() //https://dianxnao.com/ボタンクリックでシーン間を遷移%ef%bc%88移動%ef%bc%89する/
    {
        SceneManager.LoadScene("Favorite");
    }
}
