using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoPauseScript : MonoBehaviour
{
    bool paused;
    void Start()
    {
        paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (paused)//あったら削除
            {
                Scene scene = SceneManager.GetSceneByName("Pause");
                SceneManager.UnloadSceneAsync(scene);
            }
            else//ないので表示
            {
                SceneManager.LoadScene("Pause", LoadSceneMode.Additive);
            }
            paused = !paused;
        }
    }
}
