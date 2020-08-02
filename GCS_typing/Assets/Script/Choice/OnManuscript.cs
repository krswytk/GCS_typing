using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnManuscript : MonoBehaviour
{
    private bool Display;//原稿本文を表示中かどうかの判定


    // Start is called before the first frame update
    void Start()
    {
        Display = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnManuscripts()
    {
        Display = true;

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
