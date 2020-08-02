using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnDictionary : MonoBehaviour
{
    public void OnDictionarys()
    {
        SceneManager.LoadScene("Dictionary");
    }
}
/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnDictionary : MonoBehaviour
{
    [SerializeField] AudioClip sound1;
    AudioSource audioSource;
    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnDictionarys()
    {
        audioSource.PlayOneShot(sound1);
        SceneManager.LoadScene("Dictionary");
    }
}
*/
