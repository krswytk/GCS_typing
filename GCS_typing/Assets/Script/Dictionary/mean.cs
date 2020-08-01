using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mean : MonoBehaviour
{
    public int meanNumber;
    public GameObject _text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Text text = _text.GetComponent<Text>();
        switch (meanNumber)
        {
            case 1:
                text.text = "2019年に中国武漢市付近で初めて\n" +
                    "確認された新種のウイルス。接触感染、\n" +
                    "飛沫感染、エアロゾル感染などが\n" +
                    "感染経路として挙げられる。";
                break;
            case 2:
                text.text = "感染経路の一種で、ウイルスの\n" +
                    "付着した手、口等の皮膚や粘膜、\n" +
                    "または手摺、ドアノブなどの物体表面を\n" +
                    "介して他人に病原体が付着した結果に\n" +
                    "感染が成立する。";
                break;
            case 3:
                text.text = "感染経路の一種で、感染者の咳、\n" +
                    "くしゃみ等によって飛散する\n" +
                    "ウイルスを含んだ体液の粒子(飛沫)が\n" +
                    "他人の粘膜に付着することで成立する。\n";
                break;
        }
    }
}
