using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minichange : MonoBehaviour
{
 
    SpriteRenderer MainSpriteRenderer;
    // publicで宣言し、inspectorで設定可能にする
    public Sprite Sprite1;
    public Sprite Sprite2;
    public Sprite Sprite3;
    public Sprite Sprite4;
    public Sprite Sprite5;
    public Sprite Sprite6;
    public Sprite Sprite7;
    public Sprite Sprite8;

    bool sw = false;
    int no = 1;
    private float flashtime;//ピカピカします

    void Start()
    {
        // このobjectのSpriteRendererを取得
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        flashtime = 0f;
    }

    void Update()
    {
        flashtime += Time.deltaTime;
        if (no == 1)
        {
            MainSpriteRenderer.sprite = Sprite1;
        }else if (no == 2)
        {
            MainSpriteRenderer.sprite = Sprite2;
        }
        else if (no == 3)
        {
            MainSpriteRenderer.sprite = Sprite3;
        }
        else if (no == 4)
        {
            MainSpriteRenderer.sprite = Sprite4;
        }
        else if (no == 5)
        {
            MainSpriteRenderer.sprite = Sprite5;
        }
        else if (no == 6)
        {
            MainSpriteRenderer.sprite = Sprite6;
        }
        else if (no == 7)
        {
            MainSpriteRenderer.sprite = Sprite7;
        }
        else if (no == 8)
        {
            MainSpriteRenderer.sprite = Sprite8;
        }

        if (flashtime>=0.5f)
        {
            flashtime = 0f;
            if (sw == false)
            {
                no++;
            }
            sw = true;
        }
        else
        {
            sw = false;
        }
        if (no > 8) {
            no = 1;
        }
    }

}
