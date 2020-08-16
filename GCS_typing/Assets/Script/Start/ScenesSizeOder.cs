//このコードをゲーム開始時に最初に読み込むスクリプトファイル（プレイヤー系やタイトル系など）に追記する。画面サイズはスクリプトをアタッチされたオブジェクトのインスペクター上で指定
///http://inter-high-blog.unity3d.jp/2017/08/22/resolutionchange/

using UnityEngine;
using System.Collections;
public class ScenesSizeOder : MonoBehaviour
{ //xxxxにはスクリプト自体のファイル名が入る

    public int ScreenWidth;
    public int ScreenHeight;

    void Awake()
    {
        // PC向けビルドだったらサイズ変更
        if (Application.platform == RuntimePlatform.WindowsPlayer ||
        Application.platform == RuntimePlatform.OSXPlayer ||
        Application.platform == RuntimePlatform.LinuxPlayer)
        {
            Screen.SetResolution(ScreenWidth, ScreenHeight, false);
        }
    }
}