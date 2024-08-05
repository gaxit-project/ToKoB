using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class HPDecrease : MonoBehaviour
{
    public GameObject[] images; // 参照する画像の配列
    public int Hp;
    public UnityEvent Damage = new UnityEvent();

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
                SceneManager.LoadScene("Clear");
            }
        }
    }
}
