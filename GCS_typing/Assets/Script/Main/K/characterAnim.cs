using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class characterAnim : MonoBehaviour
{
    int num;
    Image A;

    [SerializeField] Sprite[] im;
    // Start is called before the first frame update
    void Start()
    {
        num = 0;
        A = GetComponent<Image>();

        A.sprite = im[num];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            Debug.Log(num);
            num++;
            A.sprite = im[num];
            if(num >= im.Length-1)
            {
                num = -1;
            }
        }
    }
}
