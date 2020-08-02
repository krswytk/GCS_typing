using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class OnStart : MonoBehaviour
{
    [SerializeField] AudioClip sound1;
    AudioSource audioSource;
    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnStarts()
    {
        audioSource.PlayOneShot(sound1);
        SceneManager.LoadScene("Main");
    }

}
