using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerFade : MonoBehaviour
{
    [SerializeField] float FFadeTime = 0.7f;
    [SerializeField] float RFadeTime = 0.3f;
    [SerializeField] GameObject WhiteFadeObject;

    private static Image WhiteFadeObjectColorImage;
    
    public void WhiteFade(GameObject WhiteFadeObject)
    {
        WhiteFadeObjectColorImage = WhiteFadeObject.GetComponent<Image>();
        WhiteFadeObjectColorImage.color = new Color(1, 1, 1, 0);
        for (int i = 0; i <= 255; i++)
        {
            StartCoroutine(start(Map(i, 0, 255, 0, FFadeTime), i, () =>//徐々に値を増やす　最後がtimerの値になる
            {

            }));
            Debug.Log(i);
        }
        /*
        c = 0;
        for (int i = 0; i <= 255; i += c)
        {
            StartCoroutine(end(Map(i, 0, 255, 0, FadeTime), 255 - i, () =>//徐々に値を増やす　最後がtimerの値になる
            {

            }));

            c += 1;

        }
        */

    }
    private IEnumerator start(float waitTime, int i,Action action)
    {
        yield return new WaitForSeconds(waitTime);

        WhiteFadeObjectColorImage.color = new Color(1, 1, 1, i / 255.0f);
        action();

        if (i == 253)
        {
            int c = 0;
            for (int l = 0; l <= 255; l += c)
            {
                StartCoroutine(end(Map(l, 0, 255, 0, RFadeTime), 255 - l, () =>//徐々に値を増やす　最後がtimerの値になる
                {

                }));

                c += 1;

            }
        }
    }
    private IEnumerator end(float waitTime, int i, Action action)
    {
        yield return new WaitForSeconds(waitTime);

        WhiteFadeObjectColorImage.color = new Color(1, 1, 1, i / 255.0f);
        action();
    }
    float Map(float value, float start1, float stop1, float start2, float stop2)
    {
        return start2 + (stop2 - start2) * ((value - start1) / (stop1 - start1));
    }

}
