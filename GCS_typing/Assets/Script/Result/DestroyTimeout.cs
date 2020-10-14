using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DestroyTimeout : MonoBehaviour
{
    [SerializeField] private GameObject Difficulty;
    [SerializeField] private GameObject an;
    [SerializeField] private GameObject tx;
    [SerializeField] private GameObject tx2;
    public float outtimer;
    int seconds;

    [SerializeField] private Sprite[] anImage; 
    private string[] text;
    private Text t,t2;
    private Image i;
    
    [SerializeField] AudioClip[] sound;
    private AudioSource audioSource;

    private int n;
    // [SerializeField] private sp

    private float countTime = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        if (Text_choice.Failure < 10)
            n = 4;
        else if (Text_choice.Failure > 10 && Text_choice.Failure < 20)
            n = 3;
        else if (Text_choice.Failure > 20 && Text_choice.Failure < 30)
            n = 2;
        else if (Text_choice.Failure > 30 && Text_choice.Failure < 40)
            n = 1;

        //Difficulty = GameObject.Find("Difficulty");
        //Destroy(Difficulty, outtimer);

        text = new string[5];
        text[0] = "うーん・・・。\n勉強あるのみですね。";
        text[1] = "学ぶことは多いと思いますが\n一緒に頑張りましょう"; 
        text[2] = "良いですね！\n一緒にもう少し\n頑張っていきましょう！";
        text[3] = "とても良い感じです！\n次も貴方と一緒に\n頑張りたいです！";
        text[4] = "素晴らしい結果ですね！\n貴方の知識\n私も見習いたいです";

        t = tx.GetComponent<Text>();
        t2 = tx2.GetComponent<Text>();
        i = an.GetComponent<Image>();
        
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(sound[n]);
        Result(0);
    }

    // Update is called once per frame
    void Update()
    {
        
        outtimer -= Time.deltaTime;
        seconds = (int)outtimer+1;
        t2.text = seconds.ToString() + "秒後にセレクト画面に移行します";
        if(seconds < 1)
        {
            Timer.countTime = 0;
            SceneManager.LoadScene("Choice");
        }
        countTime -= Time.deltaTime;
        if (countTime < 0.0f)
            Result(1);
    }

    private void Result(int count)
    {
        if (count == 0)
            t.text = "タイム　" + Timer.countTime.ToString() + "\n" + "ミスタイプ数　" + Text_choice.Failure.ToString() + "\n";
        else
            t.text = text[n];
        i.sprite = anImage[n];
        
    }

    public void SetScore(int i)
    {
        n = i;
        //Result();
    }
}
