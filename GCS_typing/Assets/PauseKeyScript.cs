using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseKeyScript : MonoBehaviour
{
    [SerializeField] GameObject backbutton;//Serializedが何かはわかりません
    [SerializeField] GameObject choicebutton;//ボタンの背景的な青い画像を
    [SerializeField] GameObject exsitbutton;//インスペクタから入れました

    private Canvas Canvas;
    private PauseDestroyScript pauseDestroyScript;

    private int num;//現在のキーの場所 1B 2C 3E

    // Start is called before the first frame update
    void Start()
    {
        pauseDestroyScript = GameObject.Find("Canvas").GetComponent<PauseDestroyScript>();
        num = 0;
        CK();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)//何らかのボタンが押された場合
        {
            switch (num)//もっと楽できる
            {
                case 0://初期
                    if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))//上系のボタンが押された
                    {
                        num = 1;// audioSource.PlayOneShot(select);//まだ実装してない
                    }
                    if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))//下系のボタンが押された
                    {
                        num = 3; //audioSource.PlayOneShot(select);
                    }
                    break;

                case 1://一番上にフォーカス
                    if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))//上系のボタンが押された
                    {
                        num = 3;// audioSource.PlayOneShot(select);//ループ的な
                    }
                    if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))//下系のボタンが押された
                    {
                        num = 2; //audioSource.PlayOneShot(select);
                    }
                    break;

                case 2://真ん中にフォーカス0と同じでよいのでは？
                    if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))//上系のボタンが押された
                    {
                        num = 1;// audioSource.PlayOneShot(select);//ループ的な
                    }
                    if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))//下系のボタンが押された
                    {
                        num = 3; //audioSource.PlayOneShot(select);
                    }
                    break;

                case 3://一番下にフォーカス
                    if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))//上系のボタンが押された
                    {
                        num = 2;// audioSource.PlayOneShot(select);//ループ的な
                    }
                    if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))//下系のボタンが押された
                    {
                        num = 1; //audioSource.PlayOneShot(select);
                    }
                    break;

                default:
                    break;
            }
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))//決定押されたとき
            {
                switch (num)
                {
                    case 0:break;
                    case 1://メニューに戻る的な
                        pauseDestroyScript.PauseDestroyfunc();
                        break;
                    case 2:
                        pauseDestroyScript.GoChoicefunc();
                        break;
                    case 3:
                        pauseDestroyScript.Exsitfunc();
                        break;
                }
            }

            CK();
        }   
    }

    void CK()
    {
        backbutton.SetActive(false);
        choicebutton.SetActive(false);
        exsitbutton.SetActive(false);


        switch (num)
        {
            case 0://初期状態的な何か
                break;
            case 1:
                backbutton.SetActive(true);
                break;
            case 2:
                choicebutton.SetActive(true);
                break;
            case 3:
                exsitbutton.SetActive(true);
                break;

            default:
                break;
        }
    }

}
