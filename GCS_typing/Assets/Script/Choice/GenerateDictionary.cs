using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateDictionary : MonoBehaviour
{
    [SerializeField] private GameObject Manuscript;//原稿素材をインスペクターから格納
                                                   //[SerializeField] private int Number;//生成する原稿数

    private int Number;
    public GameObject[] Manuscripts;

    // Start is called before the first frame update
    void Start()
    {
        Number = this.GetComponent<FileNumber>().GetFN();
        Debug.Log("原稿数取得");

        Manuscripts = new GameObject[Number];
        Debug.Log("原稿数で初期化");

        for (int i = 0; i < Number; i++)//原稿を生成　thisの子にする　thisを回転　これを繰り返す
        {
            Manuscripts[i] = Instantiate(Manuscript, new Vector3(0.0f, 0.0f, 2f), Quaternion.identity, this.transform);

            Debug.Log((i+1)+"個目の原稿を生成");
            this.transform.Rotate(new Vector3(0, 360 / Number, 0));
            Debug.Log("回転");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
