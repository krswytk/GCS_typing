using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menekey : MonoBehaviour
{
    [SerializeField] GameObject SK;
    [SerializeField] GameObject CK;

    //private OnDictionary OnDictionary;
    private titlestart titlestart;

    private int num;//現在のキーの場所 1T 2D 3R 4L 5S

    // Start is called before the first frame update
    void Start()
    {
        num = 0;
        CcK();
        titlestart = GameObject.Find("EventSystem").GetComponent<titlestart>();
        //OnDictionary = GameObject.Find("Dictionary").GetComponent<OnDictionary>();
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
                        num = 1;
                    }
                    if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))//右系のボタンが押された
                    {
                        num = 1;
                    }
                    if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))//上系のボタンが押された
                    {
                        num = 2;
                    }
                    if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))//下系のボタンが押された
                    {
                        num = 1;
                    }
                    break;
                case 1:
                    if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))//左系のボタンが押された
                    {
                        num = 1;
                    }
                    if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))//右系のボタンが押された
                    {
                        num = 1;
                    }
                    if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))//上系のボタンが押された
                    {
                        num = 2;
                    }
                    if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))//下系のボタンが押された
                    {
                        num = 1;
                    }
                    break;
                case 2:
                    if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))//左系のボタンが押された
                    {
                        num = 1;
                    }
                    if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))//右系のボタンが押された
                    {
                        num = 1;
                    }
                    if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))//上系のボタンが押された
                    {
                        num = 2;
                    }
                    if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))//下系のボタンが押された
                    {
                        num = 1;
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
        CcK();
    }

    public void CcK()
    {
        SK.SetActive(false);
        CK.SetActive(false);

        switch (num)
        {
            case 0:
                break;
            case 1:
                SK.SetActive(true);
                break;
            case 2:
                CK.SetActive(true);
                break;
            default:
                Debug.LogError("欄外になっています。選択枠のエラーです/003");
                break;
        }
    }
}
