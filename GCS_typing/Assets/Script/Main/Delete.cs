using UnityEngine;
using System.Collections.Generic;

public class Delete : MonoBehaviour
{
    private void Update()
    {
        //ITimedText.SetText();
    }
}

    public abstract class ITimedText<T>
    : MonoBehaviour
{
    /// <summary>
    /// １文字の待ち時間
    /// </summary>
    [SerializeField]
    float m_waitDuration = 0.0f;

    /// <summary>
    /// 文字を全部表示した時に呼ぶイベント
    /// </summary>
    [SerializeField]
    UnityEngine.Events.UnityEvent m_onTextEndEvent = null;

    // 表示に使用するコンポーネント
    protected T m_textComponent;

    // 文字全文
    string m_text;

    // 次の文字までのタイマー
    float m_timer;

    // 現在表示する最後の文字の位置
    int m_currentIndex;

    void Start()
    {
        Initialize();
    }

    protected virtual void Initialize()
    {
        m_text = "";
        m_timer = m_waitDuration;
        m_currentIndex = 0;
        SetupTextComponent();
    }

    /// <summary>
    /// テキストコンポーネントの設定
    /// </summary>
    protected abstract void SetupTextComponent();

    /// <summary>
    /// 表示する文字をテキストコンポーネントに設定する
    /// </summary>
    /// <param name="text">表示する文字</param>
    protected abstract void SetTextDisplay(string text);
    public bool IsLastIndex { get { return (m_currentIndex >= m_text.Length); } }

    void Update()
    {
        UpdateText();
    }

    protected virtual void UpdateText()
    {
        if (IsLastIndex)
        {
            return;
        }

        m_timer += Time.deltaTime;
        if (m_timer< m_waitDuration)
        {
            return;
        }

        // 次の文字に移動する
        m_currentIndex++;
        m_timer = 0.0f;

        // 表示する文字を設定
        SetTextDisplay(m_text.Substring(0, m_currentIndex));

        if (m_onTextEndEvent != null && IsLastIndex)
        {
            // 最後に達したので、イベントを飛ばす
            m_onTextEndEvent.Invoke();
        }
    }

    public void SetText(string text)
    {
        m_text = text;
        m_currentIndex = 0;
        m_timer = 0.0f;
        SetTextDisplay("");
    }

    public class UITimedText
    : ITimedText<UnityEngine.UI.Text>
    {
        protected override void SetupTextComponent()
        {
            m_textComponent = GetComponent<UnityEngine.UI.Text>();
        }

        protected override void SetTextDisplay(string text)
        {
            m_textComponent.text = text;
        }
    }
}