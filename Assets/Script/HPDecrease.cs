using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using TMPro;

public class HPDecrease : MonoBehaviour
{
    public GameObject[] images; // 参照する画像の配列
    public int Hp;
    public UnityEvent Damage = new UnityEvent();
    public TextMeshProUGUI countdownText; // TextMeshProコンポーネントへの参照
    public bool Dye=false;


    public IEnumerator DestroyImagesCoroutine()
    {
        foreach (GameObject image in images)
        {
            if (image != null)
            {
                Destroy(image);
                Hp--;
                Damage.Invoke();
                Debug.Log(image.name + "を破壊しました。");
                yield return new WaitForSeconds(1f); // 1秒待つ
            }

            if(Hp==1){
                StartCoroutine(CountdownFinished()); // HPなくなり
                Dye=true;
            }
        }
    }

    IEnumerator CountdownFinished()
    {
        Debug.Log("HPが０");
        countdownText.text = "Finish!";
        yield return new WaitForSeconds(3f); // 3秒間待機
        SceneManager.LoadScene("Clear"); // シーンを変更する
    }
}
