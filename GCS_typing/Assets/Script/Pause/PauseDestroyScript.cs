using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseDestroyScript : MonoBehaviour
{
    
    public void PauseDestroyfunc()
    {
        Scene scene = SceneManager.GetSceneByName("Pause");//合体しているうちの、こっちだけ
        SceneManager.UnloadSceneAsync(scene);

    }
}
