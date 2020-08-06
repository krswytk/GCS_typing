using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyTimeout : MonoBehaviour
{
    [SerializeField] private GameObject Difficulty;
    [SerializeField] private GameObject an;
    [SerializeField] private GameObject tx;
    public float outtimer = 15.0f;

    [SerializeField] private Sprite[] anImage; 
    private string[] text;
    private Text t;
    private Image i;

    private int n;
    // [SerializeField] private sp

    // Start is called before the first frame update
    void Start()
    {
        //Difficulty = GameObject.Find("Difficulty");
        Destroy(Difficulty, outtimer);

        text = new string[5];
        text[0] = "流石です！これなら安心して任せられますね！";
        text[1] = "概ね良好ですね。完璧な原稿までもう少しですよ！";
        text[2] = "可もなく不可もなくといった感じですね。まだまだ成長できますよ！";
        text[3] = "ミスが少々目立ちますね。もっと頑張りましょう！";
        text[4] = "・・・練習あるのみですね。";

        t = tx.GetComponent<Text>();
        i = an.GetComponent<Image>();

        n = 5;
        c();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0)){
            c();
        }
    }

    private void c()
    {
        n++;
        if(n > 4)
        {
            n = 1;
        }
        t.text = text[n];
        i.sprite = anImage[n];

    }
}
