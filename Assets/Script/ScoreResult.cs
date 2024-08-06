using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreResult : MonoBehaviour
{
    public TextMeshProUGUI ResultText;

    private int CoinCount;　//コインのカウント
    public bool OneCount;　//1カウントするためのブール
    public int CoinInBox;

    public void CoinDrop()
    {
        ResultText.text = "Your Score is " + CoinGet.CoinCount.ToString();
    }

    IEnumerator CoinPopCoroutine()　//エネミーのターンの終了、終了後の処理を行うコルーチン
    {
        //ここに処理を書く
        Debug.Log("修正中");
        GameObject obj = (GameObject)Resources.Load("ResultCoin");
        Instantiate(obj, new Vector3(0.0f, 5, -1.5f), Quaternion.identity);


        //1フレーム停止
        yield return new WaitForSeconds(1f);　//0.5f時間をストップ

        //ここに再開後の処理を書く
        OneCount = true;
        CoinInBox = CoinInBox - 1;
        //Debug.Log("ターンエンド！");

    }

    // Start is called before the first frame update
    void Start()
    {
        CoinInBox = CoinGet.CoinCount;
        OneCount = true;
    }

    // Update is called once per frame
    void Update()
    {
        /*while (CoinInBox > 0)
        {
            StartCoroutine("CoinPopCoroutine");
        }*/
        if(CoinInBox > 0 && OneCount)
        {
            OneCount = false;
            StartCoroutine("CoinPopCoroutine");
        }
        else if(CoinInBox == 0)
        {
            CoinDrop();
        }
    }
}
