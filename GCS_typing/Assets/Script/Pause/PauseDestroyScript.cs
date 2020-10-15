using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseDestroyScript : MonoBehaviour
{
    
    public void PauseDestroyfunc()
    {
        Scene scene = SceneManager.GetSceneByName("Pause");//合体しているうちの、こっちだけ
        Debug.Log("消します");
        SceneManager.UnloadSceneAsync(scene);

    }
    public void GoChoicefunc()
    {
        SceneManager.LoadScene("Choice");
    }
    public void Exsitfunc()
    {
        Debug.Log("シューりょー");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
      UnityEngine.Application.Quit();
#endif
    }
}
