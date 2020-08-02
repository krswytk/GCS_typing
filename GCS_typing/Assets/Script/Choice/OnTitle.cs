using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnTitle : MonoBehaviour
{
    [SerializeField] AudioClip sound1;
    AudioSource audioSource;
    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void OnStart()
    {
        audioSource.PlayOneShot(sound1);
        SceneManager.LoadScene("Start");
    }

}
