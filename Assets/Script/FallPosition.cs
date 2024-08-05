using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallPosition : MonoBehaviour
{
    void Update()
    {
        // オブジェクトの現在の位置を取得
        Vector3 position = transform.position;

        // y座標が0未満の場合に処理を実行
        if (position.y < -1)
        {
            Debug.Log("オブジェクトがy座標-1より下に移動しました");
            // ここに追加の処理を記述（例: オブジェクトの破壊、リスポーン、ゲームオーバー処理など）
            SceneManager.LoadScene("Clear");
        }
    }
}
