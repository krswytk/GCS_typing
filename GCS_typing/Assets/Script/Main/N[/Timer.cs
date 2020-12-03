using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GoPauseScript GoPauseScript;

    public static float countTime = 0;
    // Use this for initialization
    void Start()
    {
        countTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        try{
            if (!GoPauseScript.paused)
            {
                countTime += Time.deltaTime; //スタートしてからの秒数を格納
            }
        }
        catch
        {
            countTime += Time.deltaTime; //スタートしてからの秒数を格納
        }
        
        //if(countTime > 99)
        GetComponent<Text>().text =countTime.ToString("F2"); //小数2桁にして表示
    }
}