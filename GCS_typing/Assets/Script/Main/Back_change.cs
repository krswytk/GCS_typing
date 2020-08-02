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

    void Start()
    {
        // このobjectのSpriteRendererを取得
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
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
