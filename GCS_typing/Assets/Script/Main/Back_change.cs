using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back_change : MonoBehaviour
{
    SpriteRenderer MainSpriteRenderer;
    // publicで宣言し、inspectorで設定可能にする
    public Sprite beforeSprite;
    public Sprite afterSprite;

    bool sw = false;
    private float flashtime;
    void Start()
    {
        // このobjectのSpriteRendererを取得
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        flashtime = 0f;
    }

    void Update()
    {
        flashtime += Time.deltaTime;
        if (flashtime>=1.5f)//均等にパカパカするのは変かも？
        {
            flashtime = 0f;
            if (sw == false)
            {
                MainSpriteRenderer.sprite = afterSprite;
                sw = true;
            }
            else
            {
                MainSpriteRenderer.sprite = beforeSprite;
                sw = false;
            }
        }
    }
}
