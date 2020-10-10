using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyTimeout : MonoBehaviour
{
    [SerializeField] private GameObject Difficulty;
    [SerializeField] private GameObject an;
    [SerializeField] private GameObject tx;
    [SerializeField] private GameObject tx2;
    public float outtimer = 15.0f;
    int seconds;

    [SerializeField] private Sprite[] anImage; 
    private string[] text;
    private Text t,t2;
    private Image i;
    
    [SerializeField] AudioClip[] sound;
    private AudioSource audioSource;

    private int n = 3;
    // [SerializeField] private sp

    // Start is called before the first frame update
    void Start()
    {
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
        Risult();
    }

    // Update is called once per frame
    void Update()
    {
        outtimer -= Time.deltaTime;
        seconds = (int)outtimer+1;
        t2.text = seconds.ToString() + "秒後にセレクト画面に移行します";
        if(seconds < 0)
        {
            Difficulty.SetActive(false);
        }
    }

    private void Risult()
    {
        t.text = "タイム\n" + "ミスタイプ数　" + Text_choice.Failure.ToString("000")+  "\n" + text[n];
        i.sprite = anImage[n];
        audioSource.PlayOneShot(sound[n]);
    }

    public void SetScore(int i)
    {
        n = i;
        Risult();
    }
}
