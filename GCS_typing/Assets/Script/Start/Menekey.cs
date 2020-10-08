using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menekey : MonoBehaviour
{
    [SerializeField] GameObject SK;
    [SerializeField] GameObject KK;

    //private OnDictionary OnDictionary;
    private titlestart titlestart;

    private int num;//現在のキーの場所 1S 2K

    [SerializeField] AudioClip select;
    [SerializeField] AudioClip enter;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        num = 0;
        CK();
        titlestart = GameObject.Find("EventSystem").GetComponent<titlestart>();
        //OnDictionary = GameObject.Find("Dictionary").GetComponent<OnDictionary>();

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)//キーが押されたら
        {
            switch (num)
            {
                case 0:
                    if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))//左系のボタンが押された
                    {
                        num = 1; audioSource.PlayOneShot(select);
                    }
                    if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))//右系のボタンが押された
                    {
                        num = 1; audioSource.PlayOneShot(select);
                    }
                    if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.C))//上系のボタンが押された
                    {
                        num = 2; audioSource.PlayOneShot(select);
                    }
                    if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))//下系のボタンが押された
                    {
                        num = 1; audioSource.PlayOneShot(select);
                    }
                    break;
                case 1:
                    if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))//左系のボタンが押された
                    {
                        num = 1;
                        titlestart.OnClickStartButton(); audioSource.PlayOneShot(enter);
                    }
                    if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))//右系のボタンが押された
                    {
                        num = 1;
                        titlestart.OnClickStartButton(); audioSource.PlayOneShot(enter);
                    }
                    if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.C))//上系のボタンが押された
                    {
                        num = 2; audioSource.PlayOneShot(select);
                    }
                    if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))//下系のボタンが押された
                    {
                        num = 1;
                        titlestart.OnClickStartButton(); audioSource.PlayOneShot(enter);
                    }
                    break;
                case 2:
                    if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))//左系のボタンが押された
                    {
                        num = 1; audioSource.PlayOneShot(select);
                    }
                    if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))//右系のボタンが押された
                    {
                        num = 1; audioSource.PlayOneShot(select);
                    }
                    if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.C))//上系のボタンが押された
                    {
                        num = 2;
                        titlestart.Credit(); audioSource.PlayOneShot(enter);
                    }
                    if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))//下系のボタンが押された
                    {
                        num = 1; audioSource.PlayOneShot(select);
                    }
                    break;
               
                default:
                    Debug.LogError("欄外になっています。選択枠のエラーです/001");
                    break;
            }

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
            {
                switch (num)
                {
                    case 0:
                        break;
                    case 1:
                        titlestart.OnClickStartButton();
                        break;
                    case 2:
                        titlestart.Credit();
                        break;
                    default:
                        Debug.LogError("欄外になっています。選択枠のエラーです/002");
                        break;
                }
            }
        }
        CK();
    }

    private void CK()
    {
        SK.SetActive(false);
        KK.SetActive(false);

        switch (num)
        {
            case 0:
                break;
            case 1:
                SK.SetActive(true);
                break;
            case 2:
                KK.SetActive(true);
                break;
            default:
                Debug.LogError("欄外になっています。選択枠のエラーです/003");
                break;
        }
    }
}
