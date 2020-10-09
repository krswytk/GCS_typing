using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerFade : MonoBehaviour
{
    [SerializeField] float FadeTime = 1.0f;
    [SerializeField] GameObject WhiteFadeObject;

    private static Image WhiteFadeObjectColorImage;

    // Start is called before the first frame update
    void Start()
    {
        WhiteFadeObjectColorImage = WhiteFadeObject.GetComponent<Image>();
    }

    public void WhiteFade()
    {
        WhiteFadeObjectColorImage.color = new Color(1, 1, 1, 0);//徐々に1に近づける  
        for (int i = 0; i <= 255; i++)
        {
            StartCoroutine(start(Map(i, 0, 255, 0, FadeTime), i, () =>//徐々に値を増やす　最後がtimerの値になる
            {

            }));
            StartCoroutine(end(Map(i, 0, 255, 0, FadeTime), 255 - i, () =>//徐々に値を増やす　最後がtimerの値になる
            {

            }));
            
        }

    }
    private IEnumerator start(float waitTime, int i,Action action)
    {
        yield return new WaitForSeconds(waitTime);

        WhiteFadeObjectColorImage.color = new Color(1, 1, 1, i / 255.0f);
        action();
        //Debug.Log(i);
    }
    private IEnumerator end(float waitTime, int i, Action action)
    {
        yield return new WaitForSeconds(waitTime);

        WhiteFadeObjectColorImage.color = new Color(1, 1, 1, i / 255.0f);
        action();
        //Debug.Log(i);
    }
    float Map(float value, float start1, float stop1, float start2, float stop2)
    {
        return start2 + (stop2 - start2) * ((value - start1) / (stop1 - start1));
    }

}
