using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuKey : MonoBehaviour
{
    [SerializeField] GameObject TK;
    [SerializeField] GameObject DK;
    [SerializeField] GameObject RK;
    [SerializeField] GameObject LK;
    [SerializeField] GameObject SK;

    //private OnDictionary OnDictionary;
    private OnStart OnStart;
    private OnTitle OnTitle;
    private Onturn Rturn;
    private Onturn Lturn;

    private int num;//現在のキーの場所 1T 2D 3R 4L 5S

    // Start is called before the first frame update
    void Start()
    {
        num = 0;
        CK();

        //OnDictionary = GameObject.Find("Dictionary").GetComponent<OnDictionary>();
        OnStart = GameObject.Find("Start").GetComponent<OnStart>();
        OnTitle = GameObject.Find("ReTitle").GetComponent<OnTitle>();
        Rturn = GameObject.Find("RightRotation").GetComponent<Onturn>();
        Lturn = GameObject.Find("LeftRotation").GetComponent<Onturn>();
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
                        num = 4;
                    }
                    if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))//右系のボタンが押された
                    {
                        num = 3;
                    }
                    if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))//上系のボタンが押された
                    {
                        num = 1;
                    }
                    if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))//下系のボタンが押された
                    {
                        num = 5;
                    }
                    break;
                case 1:
                    if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))//左系のボタンが押された
                    {
                        num = 4;
                    }
                    if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))//右系のボタンが押された
                    {
                        num = 3;
                    }
                    if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))//上系のボタンが押された
                    {
                        num = 1;
                    }
                    if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))//下系のボタンが押された
                    {
                        num = 5;
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
                        num = 5;
                    }
                    if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))//下系のボタンが押された
                    {
                        num = 5;
                    }
                    break;
                case 3:
                    if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))//左系のボタンが押された
                    {
                        num = 4;
                    }
                    if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))//右系のボタンが押された
                    {
                        num = 3;
                        Rturn.OnRight();
                    }
                    if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))//上系のボタンが押された
                    {
                        num = 1;
                    }
                    if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))//下系のボタンが押された
                    {
                        num = 5;
                    }
                    break;
                case 4:
                    if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))//左系のボタンが押された
                    {
                        num = 4;
                        Lturn.OnLeft();
                    }
                    if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))//右系のボタンが押された
                    {
                        num = 3;
                    }
                    if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))//上系のボタンが押された
                    {
                        num = 1;
                    }
                    if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))//下系のボタンが押された
                    {
                        num = 5;
                    }
                    break;
                case 5:
                    if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))//左系のボタンが押された
                    {
                        num = 4;
                    }
                    if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))//右系のボタンが押された
                    {
                        num = 3;
                    }
                    if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))//上系のボタンが押された
                    {
                        num = 1;
                    }
                    if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))//下系のボタンが押された
                    {
                        num = 5;
                    }
                    break;
                default:
                    Debug.LogError("欄外になっています。選択枠のエラーです/001");
                    break;
            }

            if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
            {
                switch (num)
                {
                    case 0:
                        break;
                    case 1:
                        OnTitle.OnStart();
                        break;
                    case 2:
                        //OnDictionary.OnDictionarys();
                        break;
                    case 3:
                        Rturn.OnRight();
                        break;
                    case 4:
                        Lturn.OnLeft();
                        break;
                    case 5:
                        OnStart.OnStarts();
                        break;
                    default:
                        Debug.LogError("欄外になっています。選択枠のエラーです/002");
                        break;
                }
            }
        }
        CK();
    }
        
    public void CK()
    {
        TK.SetActive(false);
        DK.SetActive(false);
        RK.SetActive(false);
        LK.SetActive(false);
        SK.SetActive(false);

        switch (num)
        {
            case 0:
                break;
            case 1:
                TK.SetActive(true);
                break;
            case 2:
                DK.SetActive(true);
                break;
            case 3:
                RK.SetActive(true);
                break;
            case 4:
                LK.SetActive(true);
                break;
            case 5:
                SK.SetActive(true);
                break;
        default:
                Debug.LogError("欄外になっています。選択枠のエラーです/003");
                break;
        }
    }
}
