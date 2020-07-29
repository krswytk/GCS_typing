using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class OnStart : MonoBehaviour
{

    public void OnStarts()
    {
        SceneManager.LoadScene("Main");
    }
}
