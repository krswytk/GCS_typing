using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnTitle : MonoBehaviour
{
    public void OnStart()
    {
        SceneManager.LoadScene("Start");
    }
}
