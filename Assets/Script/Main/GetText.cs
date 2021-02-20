using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetText : MonoBehaviour
{
    public string[] text;　　//各配列に問題文が入っている
    public string[,,] debris; //各配列に出題用単語が入っている 2字要素　0に単語 1にひらがな　2にローマ字
    //[問題番号0-9  ,  回答0-3  ,  0に単語 1にひらがな　2にローマ字]
    public string[] word;    //各配列に辞書の単語が入っている
    public string[] hiragana;    //各配列に辞書の単語が入っている
    public string[] meaning; //上の要素と同じ番号に単語の意味が入っている

}
