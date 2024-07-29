using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Time : MonoBehaviour
{
    public TextMeshProUGUI countdownText; // TextMeshProコンポーネントへの参照
    private Countdown countdown; // Countdownスクリプトへの参照を追加
    public float countdownTime=30f;//スタート時のカウントダウンの時間
    public float currentTime;//現在のカウント時間


    void Start()
    {
        GameObject countObj = GameObject.Find("GameManager");
        countdown = countObj.GetComponent<Countdown>(); // Countdownスクリプトを取得
        currentTime=countdownTime;
    }

    void Update()
    {
        if (countdown != null && countdown.start) // カウントダウンが終了したかどうか
        {
            StartCoroutine(Countdown());
            this.enabled = false; // カウントダウンが開始されたら、Updateを無効にする
        }

    }

    IEnumerator Countdown()//時間を減らしていく
    {
       
        while (currentTime > 0)
        {
            countdownText.text = currentTime.ToString("0");
            yield return new WaitForSeconds(1f);
            currentTime--;
        }

        countdownText.text = "0";
        CountdownFinished();
        
    }

    void CountdownFinished()
    {
        // カウントダウンが終了したときの処理をここに記述
        Debug.Log("Countdown finished!");
    }

    public void ResetCountdown()
    {
        currentTime = countdownTime; // カウントダウン時間をリセット
        countdownText.text="30";
        Debug.Log("旗に触れる");
    }
}
