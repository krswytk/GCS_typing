using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnDictionary : MonoBehaviour
{
    [SerializeField] AudioClip sound1;
    AudioSource audioSource;
    FileNumber FN;
    TurnManeger TM;
    Seavdate SD;
    int num;//単語数
    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
        FN = GameObject.Find("TestManuscripS").GetComponent<FileNumber>();
        TM = GameObject.Find("TestManuscripS").GetComponent<TurnManeger>();
        num = FN.count;
    }

    public void OnDictionarys()
    {
        SceneManager.sceneLoaded += GameSceneLoaded;

        audioSource.PlayOneShot(sound1);
        SceneManager.LoadScene("Dictionary");
    }
    
    private void GameSceneLoaded(Scene next, LoadSceneMode mode)
    {
        GetText GT = GameObject.Find("GetText").GetComponent<GetText>();

        /////////辞書部分の渡し
        GT.word = new string[FN.count];
        Debug.Log(FN.count);
        GT.meaning = new string[FN.count];

        for (int i = 0; i < FN.count; i++)
        {
            GT.word[i] = FN.D[i].GetWord();
            GT.meaning[i] = FN.D[i].GetMeanings();
        }


        /*GT.word = new string[]{ "新型コロナウイルス", "接触感染", "飛沫感染" , "エアロゾル感染","ロックダウン","クラスター","オーバーシュート","パンデミック",
            "インフォデミック","濃厚接触","医療崩壊","スーパースプレッダー","ソーシャルディスタンス","密接","３密","PCR検査","ワクチン","臨床試験","ウィズコロナ","緊急事態宣言"};
        /////////////
        */
        //GT.word = new string[]{ "医療崩壊", "密接", "新型コロナウイルス", "マスク", "クラスター", "ソーシャルディスタンス", "PCR検査", "臨床試験", "緊急事態宣言", "ウィズコロナ"};
        

        ///////////原稿の渡し
        GT.text = FN.NM[TM.GetTMnum()].GetText();
        GT.debris = FN.NM[TM.GetTMnum()].GetDebris();
        /////////////

        SceneManager.sceneLoaded -= GameSceneLoaded;
    }

}