using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteScript : MonoBehaviour
{
    public Text Qtext;
    bool a_flag;
    float a_color;

    public string[] sentences; // 文章を格納する
    [SerializeField] Text uiText;   // uiTextへの参照

    [SerializeField]
    [Range(0.001f, 0.3f)]
    float intervalForCharDisplay = 0.05f;   // 1文字の表示にかける時間

    private int currentSentenceNum = 0; //現在表示している文章番号
    private string currentSentence = string.Empty;  // 現在の文字列
    private float timeUntilDisplay = 0;     // 表示にかかる時間
    private float timeBeganDisplay = 1;         // 文字列の表示を開始した時間
    private int lastUpdateCharCount = -1;       // 表示中の文字数
    // Use this for initialization
    void Start()
    {
        a_flag = false;
        a_color = 0;
        SetNextSentence();
    }

    // Update is called once per frame
    void Update()
    {
        //左クリックでa_flagをTrueにする
        if (Input.GetMouseButtonDown(0))
        {
            a_flag = true;
            a_color = 1;
        }
        //a_flagがtrueの間実行する
        if (a_flag)
        {
            //テキストの透明度を変更する
            Qtext.color = new Color(0, 0, 0, a_color);
            a_color -= Time.deltaTime;
            //透明度が0になったら終了する。
            if (a_color < 0)
            {
                a_color = 0;
                a_flag = false;
            }
        }

        // 文章の表示完了 / 未完了
        if (IsDisplayComplete())
        {
            //最後の文章ではない & ボタンが押された
            if (currentSentenceNum < sentences.Length && Input.GetKeyUp(KeyCode.Space))
            {
                SetNextSentence();
            }
        }
        else
        {
            //ボタンが押された
            if (Input.GetKeyUp(KeyCode.Space))
            {
                timeUntilDisplay = 0; //※1
            }
        }

        //表示される文字数を計算
        int displayCharCount = (int)(Mathf.Clamp01((Time.time - timeBeganDisplay) / timeUntilDisplay) * currentSentence.Length);
        Debug.Log(displayCharCount);
        //表示される文字数が表示している文字数と違う
        if (displayCharCount != lastUpdateCharCount)
        {
            uiText.text = currentSentence.Substring(0, displayCharCount);
            //表示している文字数の更新
            lastUpdateCharCount = displayCharCount;
        }

    }

    // 次の文章をセットする
    void SetNextSentence()
    {
        currentSentence = sentences[currentSentenceNum];
        timeUntilDisplay = currentSentence.Length * intervalForCharDisplay;
        timeBeganDisplay = Time.time;
        currentSentenceNum++;
        lastUpdateCharCount = 0;
    }

    bool IsDisplayComplete()
    {
        return Time.time > timeBeganDisplay + timeUntilDisplay; //※2
    }
}