using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteRoad : MonoBehaviour
{
    //----------------------------------いらないうしろの道の削除=====================
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Road")
        {
            Destroy(collision.gameObject); // "Road"タグのオブジェクトを破壊
            Debug.Log("Roadオブジェクトを破壊しました");
        }
    }
}
