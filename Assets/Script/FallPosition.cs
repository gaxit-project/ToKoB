using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using TMPro;

public class FallPosition : MonoBehaviour
{
    public UnityEvent Fall = new UnityEvent();
    public TextMeshProUGUI _textCountdown; // Finish表示

    void Update()
    {
        // オブジェクトの現在の位置を取得
        Vector3 position = transform.position;

        // y座標が0未満の場合に処理を実行
        if (position.y < -1)
        {
            Debug.Log("オブジェクトがy座標-1より下に移動しました");
            Fall.Invoke();
            // ここに追加の処理を記述（例: オブジェクトの破壊、リスポーン、ゲームオーバー処理など）
            StartCoroutine(CountdownFinished()); // カウントダウン終了時に2秒間待機
        }
    }

    IEnumerator CountdownFinished()
    {
        // カウントダウンが終了したときの処理
        Debug.Log("Countdown finished!");
        _textCountdown.text = "Finish!";
        yield return new WaitForSeconds(1f); // 3秒間待機
        SceneManager.LoadScene("Clear"); // シーンを変更する
    }
}
