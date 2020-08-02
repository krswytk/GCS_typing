using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContentDisplay : MonoBehaviour
{
    private Text text;
    private FileNumber FN;
    private Onturn OT;
    GameObject Manuscript;
    int num;

    // Start is called before the first frame update
    void Start()
    {
        text = this.GetComponent<Text>();
        Manuscript = GameObject.Find("TestManuscripS");
        FN = Manuscript.GetComponent<FileNumber>();
        OT = Manuscript.GetComponent<Onturn>();
    }

    // Update is called once per frame
    void Update()
    {
        num = OT.GetNum();
        Debug.Log("num : " + num);
        text.text = FN.D[num].GetText();
    }
}
