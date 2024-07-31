<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPDecrease : MonoBehaviour
{
    public GameObject[] images; // 参照する画像の配列
    public int Hp;

    public IEnumerator DestroyImagesCoroutine()
    {
        foreach (GameObject image in images)
        {
            if (image != null)
            {
                Destroy(image);
                Hp--;
                Debug.Log(image.name + "を破壊しました。");
                yield return new WaitForSeconds(1f); // 1秒待つ
            }

            if(Hp==0){
                // ゲームオーバーの処理
            }
        }
    }
}
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPDecrease : MonoBehaviour
{
    public GameObject[] images; // 参照する画像の配列
    public int Hp;

    public IEnumerator DestroyImagesCoroutine()
    {
        foreach (GameObject image in images)
        {
            if (image != null)
            {
                Destroy(image);
                Hp--;
                Debug.Log(image.name + "を破壊しました。");
                yield return new WaitForSeconds(1f); // 1秒待つ
            }

            if(Hp==0){
                // ゲームオーバーの処理
            }
        }
    }
}
>>>>>>> d31ce32f8721dfbf3054a25c735639e88d47780a
